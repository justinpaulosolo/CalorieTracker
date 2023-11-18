import { SidebarNav } from "@/components/settings/sidebar-nav";
import { Separator } from "@/components/ui/separator";
import { useOutlet } from "react-router-dom";

const sidebarNavItems = [
  {
    title: "Goals",
    href: "",
  },
  {
    title: "Account",
    href: "/settings/account",
  },
];

export default function SettingsLayout() {
  const outlet = useOutlet();
  return (
    <div className="hidden space-y-6 md:block">
      <div className="space-y-0.5">
        <h2 className="text-2xl font-bold tracking-tight">Settings</h2>
        <p className="text-muted-foreground">
          Manage your account settings and set e-mail preferences.
        </p>
      </div>
      <Separator className="my-6" />
      <div className="flex flex-col space-y-8 lg:flex-row lg:space-x-12 lg:space-y-0">
        <aside className="-mx-4 lg:w-1/5">
          <SidebarNav items={sidebarNavItems} />
        </aside>
        <div className="flex-1 lg:max-w-2xl">{outlet}</div>
      </div>
    </div>
  );
}
