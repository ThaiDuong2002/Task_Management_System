import { toTypedSchema } from "@vee-validate/zod";
import * as z from "zod";

const loginSchema = z.object({
  email: z.string().email({ message: "Invalid email address" }),
  password: z
    .string()
    .min(8, { message: "Password must be at least 8 characters long" }),
});

export default toTypedSchema(loginSchema);
export type LoginSchema = z.infer<typeof loginSchema>;
