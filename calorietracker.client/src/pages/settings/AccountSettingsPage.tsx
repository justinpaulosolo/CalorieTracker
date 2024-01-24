import { zodResolver } from "@hookform/resolvers/zod";
import { useForm } from "react-hook-form";
import { Button } from "@/components/ui/button";
import { Form, FormControl, FormField, FormItem, FormLabel, FormMessage } from "@/components/ui/form";
import { Input } from "@/components/ui/input";
import { AccountSettings, LoginUser } from "@/utils/types.ts";
import { accountSettingsSchema } from "@/utils/schemas.ts";

//TODO: Make account settings endpoint
export default function AccountSettingsPage() {

  const form = useForm<AccountSettings>({
    resolver: zodResolver(accountSettingsSchema),
    defaultValues: {
      email: "",
      username: "",
      password: ""
    }
  });

  function onSubmit(values: LoginUser) {
    console.log(values);
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
          name="email"
          render={({ field }) => (
            <FormItem className="w-72">
              <FormLabel>Email</FormLabel>
              <FormControl>
                <Input required {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />
        <FormField
          control={form.control}
          name="username"
          render={({ field }) => (
            <FormItem className="w-72">
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
            <FormItem className="w-72">
              <FormLabel>Password</FormLabel>
              <FormControl>
                <Input required type="password" {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />
        <Button className="w-72" disabled={!form.formState.isValid} type="submit">
          Submit
        </Button>
      </form>
    </Form>
  );
}
