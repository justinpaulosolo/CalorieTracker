import { zodResolver } from "@hookform/resolvers/zod";
import { useForm } from "react-hook-form";
import { Button } from "@/components/ui/button";
import { Form, FormControl, FormField, FormItem, FormLabel, FormMessage } from "@/components/ui/form";
import { Input } from "@/components/ui/input";
import { UpdateAccount, UpdateAccountDto } from "@/utils/types.ts";
import { accountSettingsSchema } from "@/utils/schemas.ts";
import { useGetUserDetails } from "@/hooks/useGetUserDetails";
import { useUpdateUser } from "@/hooks/useUpdateUser";
import {toast} from "@/components/ui/use-toast.ts";

//TODO: Make account settings endpoint
export default function AccountSettingsPage() {
  const user = useGetUserDetails();
  const updateUser = useUpdateUser()

  const form = useForm<UpdateAccount>({
    resolver: zodResolver(accountSettingsSchema),
    defaultValues: {
      email: user.data?.email ?? "",
      username: user.data?.userName ?? "",
      password: ""
    }
  });

  async function onSubmit(values: UpdateAccountDto) {
    console.log(values);
    const payload: UpdateAccountDto = {
      username: values.username,
      email: values.email,
    }
    console.log(payload, "<------ payload")
    await updateUser.mutateAsync(payload, {
      onSuccess: () => {
        console.log("Success");
        toast({title: "Account update success"})
      }, onError: () => {
        console.log("Error");
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
                <Input type="password" {...field} />
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
