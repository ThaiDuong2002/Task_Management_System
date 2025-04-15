import { toTypedSchema } from "@vee-validate/zod";
import * as z from "zod";

const ChangePasswordSchema = z
  .object({
    oldPassword: z
      .string()
      .min(8, { message: "Old password must be at least 8 characters long" })
      .max(20, { message: "Old password must be at most 20 characters long" }),
    newPassword: z
      .string()
      .min(8, { message: "New password must be at least 8 characters long" })
      .max(20, { message: "Password must be at most 20 characters long" })
      .regex(
        /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*])[A-Za-z\d!@#$%^&*]{8,}$/,
        {
          message:
            "New password must contain at least one uppercase letter, one lowercase letter, one number, and one special character",
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
    if (data.confirmPassword !== data.newPassword) {
      ctx.addIssue({
        path: ["confirmPassword"],
        code: z.ZodIssueCode.custom,
        message: "Passwords do not match",
      });
    }
  });

export default toTypedSchema(ChangePasswordSchema);
