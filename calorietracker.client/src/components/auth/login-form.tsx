import { zodResolver } from "@hookform/resolvers/zod";
import { useForm } from "react-hook-form";
import { Button } from "@/components/ui/button";
import { Form, FormControl, FormField, FormItem, FormLabel, FormMessage } from "@/components/ui/form";
import { Input } from "@/components/ui/input";
import { useNavigate } from "react-router-dom";
import { LoginUser } from "@/utils/types.ts";
import { loginFormSchema } from "@/utils/schemas.ts";
import { useLoginUser } from "@/hooks/useLoginUser.ts";

export default function LoginForm() {
  const loginUser = useLoginUser();
  const navigate = useNavigate();

  const form = useForm<LoginUser>({
    resolver: zodResolver(loginFormSchema),
    defaultValues: {
      username: "",
      password: ""
    }
  });

  function onSubmit(values: LoginUser) {
    // Todo: Show some error when login fails
    loginUser.mutate(values, {
      onSuccess: () => navigate("/")
    });
  }

  // Todo: Fix login form styling
  return (
    <Form {...form}>
      <form className="flex flex-col space-y-2" onSubmit={form.handleSubmit(onSubmit)}>
        <FormField
          control={form.control}
          name="username"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Email</FormLabel>
              <FormControl>
                <Input required placeholder="Username" {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />
        <FormField
          control={form.control}
          name="password"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Password</FormLabel>
              <FormControl>
                <Input required placeholder="Password" type="password" {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />
        <Button type="submit">Submit</Button>
      </form>
    </Form>
  );
}
