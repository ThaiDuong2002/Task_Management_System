import { toTypedSchema } from "@vee-validate/zod";
import * as z from "zod";

const ChangeImageSchema = z.object({
  image: z
    .instanceof(File, {
      message: "Please select an image",
    })
    .refine((file) => file.type.startsWith("image/"), {
      message: "File must be an image",
    })
    .refine((file) => file.size <= 1024 * 1024, {
      message: "Image size must be less than 1MB",
    })
    .refine((file) => file.size !== 0, {
      message: "Please select an image",
    }),
});

export default toTypedSchema(ChangeImageSchema);
