import { Banana } from "lucide-react";

export default function Footer() {
  return (
    <footer className="border-t w-full py-5">
      <div className="container max-w-5xl flex flex-col">
        <div className="flex space-x-2 mx-auto">
          <Banana size={22} />
          <span className="font-medium">Crispy Happiness</span>
        </div>
        <p className="mt-5 text-center text-sm leading-6 text-slate-500">© 2023 Crispy Happiness. All rights
          reserved.</p>
      </div>
    </footer>
  );
};