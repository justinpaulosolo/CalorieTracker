import { zodResolver } from "@hookform/resolvers/zod";
import { useForm } from "react-hook-form";
import * as z from "zod";
import { Button } from "@/components/ui/button";
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "@/components/ui/form";
import { Input } from "@/components/ui/input";
import { useLoginUser } from "@/utils/services/account-services";
import { useNavigate } from "react-router-dom";

const loginFormSchema = z.object({
  username: z.string(),
  password: z.string().min(10),
});

export type LoginFormInputs = z.infer<typeof loginFormSchema>;

function LoginPage() {
  const loginUser = useLoginUser();
  const navigate = useNavigate();

  const form = useForm<LoginFormInputs>({
    resolver: zodResolver(loginFormSchema),
    defaultValues: {
      username: "",
      password: "",
    },
  });

  function onSubmit(values: LoginFormInputs) {
    loginUser.mutate(values, {
      onSuccess: () => navigate("/", { replace: true }),
      onError: error => console.error(error),
    });
  }

  return (
    <div className="flex h-screen flex-1 flex-col justify-center px-16 py-12 lg:px-8 space-y-4">
      <div className="sm:mx-auto sm:w-full sm:max-w-sm">
        <h1 className="text-center text-2xl font-bold leading-9 tracking-tight">
          Login to your account
        </h1>
      </div>
      <div className="sm:mx-auto sm:w-full sm:max-w-sm">
        <div className="grid grid-6">
          <Form {...form}>
            <form onSubmit={form.handleSubmit(onSubmit)}>
              <div className="grid gap-2">
                <div className="grid gap-1">
                  <FormField
                    control={form.control}
                    name="username"
                    render={({ field }) => (
                      <FormItem>
                        <FormLabel className="sr-only">Email</FormLabel>
                        <FormControl>
                          <Input placeholder="Username" {...field} />
                        </FormControl>
                        <FormMessage />
                      </FormItem>
                    )}
                  />
                </div>
                <div className="grid gap-1">
                  <FormField
                    control={form.control}
                    name="password"
                    render={({ field }) => (
                      <FormItem>
                        <FormLabel className="sr-only">Password</FormLabel>
                        <FormControl>
                          <Input
                            placeholder="Password"
                            type="password"
                            {...field}
                          />
                        </FormControl>
                        <FormMessage />
                      </FormItem>
                    )}
                  />
                </div>
                <Button type="submit">Submit</Button>
                <div className="text-sm font-semibold tracking-tight text-foreground/80 ">
                  <a href="/register">
                    Don't have an account?
                    <span className="text-primary"> Sign up</span>
                  </a>
                </div>
              </div>
            </form>
          </Form>
        </div>
      </div>
    </div>
  );
}

export default LoginPage;
