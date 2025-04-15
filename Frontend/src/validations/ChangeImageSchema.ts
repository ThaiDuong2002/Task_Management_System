import { toTypedSchema } from "@vee-validate/zod";
import * as z from "zod";

const ChangeImageSchema = z.object({
  image: z.instanceof(File).refine((file) => file.size !== 0, {
    message: "Please select an image",
  }),
});

export default toTypedSchema(ChangeImageSchema);
