import { zodResolver } from "@hookform/resolvers/zod";
import { useForm } from "react-hook-form";
import * as z from "zod";
import { Button } from "@/components/ui/button"
import {
    Form,
    FormControl,
    FormField,
    FormItem,
    FormLabel,
    FormMessage,
} from "@/components/ui/form"
import { Input } from "@/components/ui/input"
import { useMutation } from "@tanstack/react-query";
import axios from "axios";

const formSchema = z.object({
    email: z.string().email(),
    password: z.string().min(10),
});

function useLoginUser() {
    return useMutation({
        mutationFn: (user: z.infer<typeof formSchema>) =>
        axios.post('/Account/login?useCookies=true&useSessionCookies=true', user)
    })
}


function LoginPage() {
    const loginUser = useLoginUser();

    const form = useForm<z.infer<typeof formSchema>>({
        resolver: zodResolver(formSchema),
        defaultValues: {
            email: "",
            password: "",
        },
    });

    function onSubmit(values: z.infer<typeof formSchema>) {
        // Do something with the form values.
        // ✅ This will be type-safe and validated.
        console.log(values)
        loginUser.mutate(values, {
            onSuccess: (data) => console.log(data),
            onError: (error) => console.error(error),
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
                            <FormField
                                control={form.control}
                                name="email"
                                render={({ field }) => (
                                    <FormItem>
                                        <FormLabel className="sr-only">Email</FormLabel>
                                        <FormControl>
                                            <Input placeholder="Email" {...field} />
                                        </FormControl>
                                        <FormMessage />
                                    </FormItem>
                                )}
                            />
                            </div>
                            <div className="grid gap-2">
                            <FormField
                                control={form.control}
                                name="password"
                                render={({ field }) => (
                                    <FormItem>
                                        <FormLabel className="sr-only">Password</FormLabel>
                                        <FormControl>
                                            <Input placeholder="Password" type="password" {...field} />
                                        </FormControl>
                                        <FormMessage />
                                    </FormItem>
                                )}
                            />
                            <Button type="submit">Submit</Button>
                            </div>
                        </form>
                    </Form>
                </div>
            </div>
        </div>
    )
}

export default LoginPage;