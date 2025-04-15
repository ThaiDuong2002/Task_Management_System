import { toTypedSchema } from "@vee-validate/zod";
import * as z from "zod";

const FullnameSchema = z.object({
  firstName: z.string().min(1, "First name is required"),
  lastName: z.string().min(1, "Last name is required"),
});

export default toTypedSchema(FullnameSchema);
