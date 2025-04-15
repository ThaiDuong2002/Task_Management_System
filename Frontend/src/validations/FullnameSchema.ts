import { toTypedSchema } from "@vee-validate/zod";
import * as z from "zod";

const FullnameSchema = z.object({
  firstName: z
    .string({ message: "First name is required" })
    .min(1, "First name is required"),
  lastName: z
    .string({ message: "Last name is required" })
    .min(1, "Last name is required"),
});

export default toTypedSchema(FullnameSchema);
