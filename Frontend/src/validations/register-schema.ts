import { toTypedSchema } from "@vee-validate/zod";
import * as z from "zod";

const registerSchema = z
  .object({
    username: z
      .string()
      .min(3, { message: "Username must be at least 3 characters long" })
      .max(20, { message: "Username must be at most 20 characters long" }),
    firstName: z
      .string()
      .min(1, { message: "First name must be at least 1 characters long" }),
    lastName: z
      .string()
      .min(1, { message: "Last name must be at least 1 characters long" }),
    email: z.string().email({ message: "Invalid email address" }),
    password: z
      .string()
      .min(8, { message: "Password must be at least 8 characters long" })
      .max(20, { message: "Password must be at most 20 characters long" })
      .regex(
        /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*])[A-Za-z\d!@#$%^&*]{8,}$/,
        {
          message:
            "Password must contain at least one uppercase letter, one lowercase letter, one number, and one special character",
        }
      ),
    confirmPassword: z
      .string()
      .min(8, {
        message: "Confirm password must be at least 8 characters long",
      })
      .max(20, {
        message: "Confirm password must be at most 20 characters long",
      }),
  })
  .superRefine((data, ctx) => {
    if (data.confirmPassword !== data.password) {
      ctx.addIssue({
        path: ["confirmPassword"],
        code: z.ZodIssueCode.custom,
        message: "Passwords do not match",
      });
    }
  });

export default toTypedSchema(registerSchema);
export type RegisterSchema = z.infer<typeof registerSchema>;
