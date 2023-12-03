import * as z from "zod";

// Todo: match validation with backend
export const registerFormSchema = z.object({
  email: z.string().email(),
  username: z.string().min(1).max(100),
  password: z.string().min(8).max(100)
});