import RegisterForm from "@/components/auth/register-form";
import { Link } from "react-router-dom";

function RegisterPage() {
  return (
    <div className="flex h-screen flex-1 flex-col justify-center px-16 py-12 lg:px-8 space-y-4">
      <div className="sm:mx-auto sm:w-full sm:max-w-sm">
        <h1 className="text-center text-2xl font-bold leading-9 tracking-tight">
          Create an account
        </h1>
      </div>
      <div className="sm:mx-auto sm:w-full sm:max-w-sm">
        <RegisterForm />
        <div className="text-sm font-semibold tracking-tight text-foreground/80 ">
          <Link to="/login">
            Already have an account?
            <span className="text-primary"> Sign In</span>
          </Link>
        </div>
      </div>
    </div>
  );
}

export default RegisterPage;
