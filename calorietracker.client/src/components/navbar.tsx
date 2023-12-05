import { Link, useLocation, useNavigate } from "react-router-dom";
import { Banana, UserIcon } from "lucide-react";
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuSeparator,
  DropdownMenuTrigger,
} from "@/components/ui/dropdown-menu.tsx";
import { Button } from "@/components/ui/button.tsx";
import {
  Avatar,
  AvatarFallback,
  AvatarImage,
} from "@/components/ui/avatar.tsx";
import { useGetUserDetails } from "@/hooks/useGetUserDetails.ts";
import { useLogoutUser } from "@/hooks/useLogoutUser.ts";
import { cn } from "@/lib/utils.ts";

export default function Navbar() {
  const { data: User } = useGetUserDetails();
  const logoutUser = useLogoutUser();
  const navigate = useNavigate();
  const pathName = useLocation();

  const handleNavigateToSettings = () => navigate("/settings/account");

  const handleLogout = async () => {
    await logoutUser.mutateAsync();
  };

  return (
    <header className="sticky top-0 z-50 w-full border-b bg-background/95 backdrop-blur supports-[backdrop-filter]:bg-background/60">
      <div className="container max-w-5xl flex h-14 items-center">
        <div className="mr-4 flex">
          <Link to="/" className="mr-6 flex items-center space-x-2">
            <Banana size={22} />
            <span className="font-bold">Crispy Happiness</span>
          </Link>
          <nav className="flex items-center space-x-6 text-sm font-medium">
            <Link
              to="/food-diary"
              className={cn(
                "transition-colors hover:text-foreground/80",
                pathName.pathname === "/food-diary"
                  ? "text-foreground"
                  : "text-foreground/60",
              )}
            >
              Food
            </Link>
            <Link
              to="/exercise-diary"
              className={cn(
                "transition-colors hover:text-foreground/80",
                pathName.pathname === "/exercise/diary"
                  ? "text-foreground"
                  : "text-foreground/60",
              )}
            >
              Exercise
            </Link>
          </nav>
        </div>
        <div className="flex flex-1 items-center space-x-2 justify-end">
          <div className="">
            <DropdownMenu>
              <DropdownMenuTrigger asChild>
                <Button
                  variant="ghost"
                  className="relative h-10 w-10 rounded-full"
                >
                  <Avatar className="h-10 w-10">
                    <AvatarImage />
                    <AvatarFallback>
                      <UserIcon />
                    </AvatarFallback>
                  </Avatar>
                </Button>
              </DropdownMenuTrigger>
              <DropdownMenuContent className="w-48" align="end" forceMount>
                <div className="flex items-center justify-start gap-2 p-2">
                  <div className="flex flex-col space-y-1 leading-none">
                    <p className="font-medium">{User?.userName}</p>
                    <p className="w-[200px] truncate text-sm text-muted-foreground">
                      {User?.email}
                    </p>
                  </div>
                </div>
                <DropdownMenuItem
                  onClick={handleNavigateToSettings}
                  className="cursor-pointer"
                >
                  Settings
                </DropdownMenuItem>
                <DropdownMenuSeparator />
                <DropdownMenuItem onClick={handleLogout}>
                  Log out
                </DropdownMenuItem>
              </DropdownMenuContent>
            </DropdownMenu>
          </div>
        </div>
      </div>
    </header>
  );
}
