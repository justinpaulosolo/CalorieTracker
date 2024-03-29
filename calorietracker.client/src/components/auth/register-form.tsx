import { zodResolver } from "@hookform/resolvers/zod";
import { useForm } from "react-hook-form";
import { Button } from "@/components/ui/button";
import { Form, FormControl, FormField, FormItem, FormLabel, FormMessage } from "@/components/ui/form";
import { Input } from "@/components/ui/input";
import { useNavigate } from "react-router-dom";
import { RegisterUser } from "@/utils/types.ts";
import { registerFormSchema } from "@/utils/schemas.ts";
import { useRegisterUser } from "@/hooks/useRegisterUser.ts";

export default function RegisterForm() {
  const registerUser = useRegisterUser();
  const navigate = useNavigate();

  const form = useForm<RegisterUser>({
    resolver: zodResolver(registerFormSchema),
    defaultValues: {
      email: "",
      username: "",
      password: ""
    }
  });

  async function onSubmit(values: RegisterUser) {
    await registerUser.mutateAsync(values, {
      onSuccess: () => {
        navigate('/login');
      },
      onError: () => {
        const formError = {
          type: "server",
          message: "Username or email already taken"
        };

        form.setError("email", formError);
        form.setError("username", formError);
      }
    });
  }

  // Todo: Fix register forms styling
  return (
    <Form {...form}>
      <form
        className="flex flex-col space-y-2"
        onSubmit={form.handleSubmit(onSubmit)}
      >
        <FormField
          control={form.control}
          name="email"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Email</FormLabel>
              <FormControl>
                <Input placeholder="Email" {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />
        <FormField
          control={form.control}
          name="username"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Username</FormLabel>
              <FormControl>
                <Input placeholder="Username" {...field} />
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
                <Input placeholder="Password" type="password" {...field} />
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
