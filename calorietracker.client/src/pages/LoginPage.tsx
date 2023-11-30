import LoginForm from "@/components/login-form";
import { Link } from "react-router-dom";

export default function LoginPage() {
  return (
    <div className="flex h-screen flex-1 flex-col justify-center px-16 py-12 lg:px-8 space-y-4">
      <div className="sm:mx-auto sm:w-full sm:max-w-sm">
        <h1 className="text-center text-2xl font-bold leading-9 tracking-tight">
          Login to your account
        </h1>
      </div>
      <div className="sm:mx-auto sm:w-full sm:max-w-sm">
        <div className="grid grid-6">
          <LoginForm />
          <div className="text-sm font-semibold tracking-tight text-foreground/80 ">
            <Link to="/register">
              Don't have an account?
              <span className="text-primary"> Sign up</span>
            </Link>
          </div>
        </div>
      </div>
    </div>
  );
}
