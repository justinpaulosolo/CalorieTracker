import * as z from "zod";

// Todo: match register validation with backend
export const registerFormSchema = z.object({
  email: z.string().email(),
  username: z.string().min(1).max(100),
  password: z.string().min(8).max(100)
});

// Todo: match login validation with backend
export const loginFormSchema = z.object({
  username: z.string({ required_error: "Username is required" }),
  password: z.string({ required_error: "Password is required" })
});

export const accountSettingsSchema = z.object({
  email: z.string({ required_error: "Email is required" }),
  username: z.string({ required_error: "Username is required" }),
  password: z.string({ required_error: "Password is required" })
});
