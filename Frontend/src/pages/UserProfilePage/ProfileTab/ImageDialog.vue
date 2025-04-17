<script setup lang="ts">
import { Button } from "@/components/ui/button";
import {
  Dialog,
  DialogContent,
  DialogDescription,
  DialogHeader,
  DialogTitle,
  DialogTrigger,
} from "@/components/ui/dialog";
import {
  FormControl,
  FormField,
  FormItem,
  FormMessage,
} from "@/components/ui/form";
import FormLabel from "@/components/ui/form/FormLabel.vue";
import { UserService } from "@/services";
import { useAuthStore } from "@/stores";
import ChangeImageSchema from "@/validations/ChangeImageSchema";
import { ImagePlus } from "lucide-vue-next";
import { useForm } from "vee-validate";
import { ref } from "vue";
import { useDropzone } from "vue3-dropzone";

const auth = useAuthStore();
const preview = ref<string | ArrayBuffer | null>(null);

const { isFieldDirty, handleSubmit, setFieldValue, setErrors, resetField } =
  useForm({
    validationSchema: ChangeImageSchema,
    initialValues: {
      image: new File([""], "filename"),
    },
  });

const { fileRejections, getRootProps, getInputProps, isDragActive } =
  useDropzone({
    onDrop: (acceptedFiles, _) => {
      const reader = new FileReader();
      try {
        reader.onload = () => (preview.value = reader.result);
        reader.readAsDataURL(acceptedFiles[0]);
        setFieldValue("image", acceptedFiles[0]);
        setErrors({ image: "" });
      } catch (error) {
        preview.value = null;
        resetField("image");
      }
    },
    maxFiles: 1,
    maxSize: 1024 * 1024,
  });

const onSubmit = handleSubmit(async (values) => {
  const { image } = values;
  try {
    const imageUrl = await UserService.changeImage({ image });
    console.log(imageUrl);
  } catch (error) {}
});

const handleClose = () => {
  preview.value = null;
  resetField("image");
};
</script>

<template>
  <Dialog>
    <DialogTrigger as-child><slot /></DialogTrigger>
    <DialogContent @close-auto-focus="handleClose">
      <DialogHeader>
        <DialogTitle>Change Profile Photo</DialogTitle>
        <DialogDescription>
          Customize your account by adding a profile photo. This image will be
          displayed on apps and devices that utilize your account.
        </DialogDescription>
      </DialogHeader>
      <form @submit.prevent="onSubmit" class="space-y-4">
        <FormField name="image" :validate-on-blur="!isFieldDirty('image')">
          <FormItem v-auto-animate>
            <FormLabel
              :class="{ 'text-destructive': fileRejections.length !== 0 }"
            >
            </FormLabel>
            <FormControl>
              <div
                v-bind="getRootProps()"
                class="flex flex-col justify-center items-center gap-y-2 shadow-foreground shadow-sm p-8 border border-foreground rounded-lg cursor-pointer"
              >
                <img
                  v-if="preview"
                  :src="preview as string"
                  alt="Preview"
                  class="rounded-lg max-h-[400px]"
                />
                <ImagePlus v-else class="size-40" />
                <input v-bind="getInputProps()" type="file" accept="image/*" />
                <p v-if="isDragActive">Drop your image here...</p>
                <p v-else>Click to upload an image</p>
              </div>
            </FormControl>
            <FormMessage>
              <p v-if="fileRejections.length !== 0">
                Image must be less than 1MB and of type png, jpg, or jpeg
              </p>
            </FormMessage>
          </FormItem>
        </FormField>
        <div class="flex justify-center items-center w-full">
          <Button type="submit" size="lg" class="text-lg cursor-pointer">
            Change Image
          </Button>
        </div>
      </form>
    </DialogContent>
  </Dialog>
</template>

<style scoped></style>
