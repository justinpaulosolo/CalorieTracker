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
      onSuccess: () => navigate("/"),
      onError: error => {
        const formError = {
          type: "server",
          message: "Invalid username or password"
        };

        form.setError("username", formError);
        form.setError("password", formError);
        console.log(error);
      }
    });
  }

  // Todo: Fix login forms styling
  return (
    <Form {...form}>
      <form
        className="flex flex-col space-y-2"
        onSubmit={form.handleSubmit(onSubmit)}
      >
        <FormField
          control={form.control}
          name="username"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Username</FormLabel>
              <FormControl>
                <Input required {...field} />
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
                <Input required type="password" {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />
        <Button disabled={!form.formState.isValid} type="submit">
          Submit
        </Button>
      </form>
    </Form>
  );
}
