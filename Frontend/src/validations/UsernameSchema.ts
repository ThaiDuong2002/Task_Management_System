import { toTypedSchema } from "@vee-validate/zod";
import * as z from "zod";

const UsernameSchema = z.object({
  username: z.string()
  .min(3, { message: "Username must be at least 3 characters long" })
  .max(20, { message: "Username must be at most 20 characters long" })
})


export default toTypedSchema(UsernameSchema);
