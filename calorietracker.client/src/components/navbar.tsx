import { Link } from 'react-router-dom';
import { Banana, User } from 'lucide-react';
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuSeparator,
  DropdownMenuTrigger,
} from '@/components/ui/dropdown-menu.tsx';
import { Button } from '@/components/ui/button.tsx';
import {
  Avatar,
  AvatarFallback,
  AvatarImage,
} from '@/components/ui/avatar.tsx';
import { useGetUserInfo, useLogoutUser } from '@/utils/services/account-services';

export default function Navbar() {
  const { data } = useGetUserInfo();
  const logout = useLogoutUser();

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
                  <User />
                </AvatarFallback>
              </Avatar>
            </Button>
          </DropdownMenuTrigger>
          <DropdownMenuContent className="w-48" align="end" forceMount>
            <div className="flex items-center justify-start gap-2 p-2">
              <div className="flex flex-col space-y-1 leading-none">
                <p className="font-medium">{data.username}</p>
                <p className="w-[200px] truncate text-sm text-muted-foreground">
                  {data.email}
                </p>
              </div>
            </div>
            <DropdownMenuItem>Dashboard</DropdownMenuItem>
            <DropdownMenuSeparator />
            <DropdownMenuItem
              onSelect={()=> logout.mutate()}
              className="cursor-pointer"
            >
              Logout
            </DropdownMenuItem>
          </DropdownMenuContent>
        </DropdownMenu>
      </div>
    </header>
  );
}