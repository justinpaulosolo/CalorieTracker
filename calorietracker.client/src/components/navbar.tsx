import { Link, useNavigate } from "react-router-dom";
import { Banana, UserIcon } from "lucide-react";
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuSeparator,
  DropdownMenuTrigger
} from "@/components/ui/dropdown-menu.tsx";
import { Button } from "@/components/ui/button.tsx";
import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar.tsx";
import { useGetUserDetails } from "@/hooks/useGetUserDetails.ts";
import { useLogoutUser } from "@/hooks/useLogoutUser.ts";

export default function Navbar() {
  const { data: User } = useGetUserDetails();
  const logoutUser = useLogoutUser();
  const navigate = useNavigate();

  const handleNavigateToSettings = () => navigate("/settings/account");

  const handleLogout = async () => {
    await logoutUser.mutateAsync();
  };

  return (
    <header className="bg-background">
      <div className="container max-w-4xl flex h-16 justify-between items-center">
        <Link to="/" className="flex items-center space-x-2">
          <Banana size={22} />
          <span className="font-bold">Crispy Happiness</span>
        </Link>
        <DropdownMenu>
          <DropdownMenuTrigger asChild>
            <Button variant="ghost" className="relative h-10 w-10 rounded-full">
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
                <p className="font-medium">{User?.username}</p>
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
              Logout
            </DropdownMenuItem>
          </DropdownMenuContent>
        </DropdownMenu>
      </div>
    </header>
  );

}
