import * as React from "react";
import {
  NavigationMenu,
  NavigationMenuContent,
  NavigationMenuItem,
  NavigationMenuList,
  NavigationMenuTrigger,
} from "@/components/ui/navigation-menu";
import { Link, LinkProps } from "react-router-dom";
import { cn } from "@/lib/utils.ts";

const components: { title: string; href: string; description: string }[] = [
  {
    title: "Food Diary Dashboard",
    href: "/food-diary",
    description:
      "A dashboard for viewing your food diary entries and statistics.",
  },
  {
    title: "Detailed View",
    href: "/food-diary/detailed",
    description:
      "A detailed view for viewing your food diary entries broken down by meals",
  },
];

export function Navigation() {
  return (
    <NavigationMenu>
      <NavigationMenuList>
        <NavigationMenuItem>
          <NavigationMenuTrigger>Foods</NavigationMenuTrigger>
          <NavigationMenuContent>
            <ul className="p-6 w-[400px]">
              {components.map(component => (
                <ListItem
                  key={component.title}
                  title={component.title}
                  to={component.href}
                >
                  {component.description}
                </ListItem>
              ))}
            </ul>
          </NavigationMenuContent>
        </NavigationMenuItem>
      </NavigationMenuList>
    </NavigationMenu>
  );
}

const ListItem = React.forwardRef<HTMLAnchorElement, LinkProps>(
  ({ className, title, children, ...props }, ref) => {
    return (
      <li>
        <Link
          ref={ref}
          className={cn(
            "block select-none space-y-1 rounded-md p-3 leading-none no-underline outline-none transition-colors hover:bg-accent hover:text-accent-foreground focus:bg-accent focus:text-accent-foreground",
            className,
          )}
          {...props}
        >
          <div className="text-sm font-medium leading-none">{title}</div>
          <p className="line-clamp-2 text-sm leading-snug text-muted-foreground">
            {children}
          </p>
        </Link>
      </li>
    );
  },
);

ListItem.displayName = "ListItem";
