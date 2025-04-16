<script setup lang="ts">
import { Button } from "@/components/ui/button";
import {
  Dialog,
  DialogClose,
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
  FormLabel,
  FormMessage,
} from "@/components/ui/form";
import { Input } from "@/components/ui/input";
import { UserService } from "@/services";
import { useAuthStore } from "@/stores";
import FullnameSchema from "@/validations/FullnameSchema";
import { useForm, useSetFormErrors } from "vee-validate";
import { ref } from "vue";
import { toast } from "vue-sonner";

const { isFieldDirty, handleSubmit } = useForm({
  initialValues: {
    firstName: "",
    lastName: "",
  },
  validationSchema: FullnameSchema,
});

const setError = useSetFormErrors();
const auth = useAuthStore();
const isOpen = ref(false);

const openDialog = () => {
  isOpen.value = true;
};
const closeDialog = () => {
  isOpen.value = false;
};

const onSubmit = handleSubmit(async (values) => {
  const { firstName, lastName } = values;
  try {
    await UserService.updateUser({
      firstName,
      lastName,
    });

    auth.setUser({
      firstName,
      lastName,
    });

    closeDialog();

    toast.success("Fullname updated successfully", {
      description: "Your fullname has been updated successfully.",
    });

    setError({ firstName: "", lastName: "" });
  } catch (error: any) {
    setError({ lastName: error.message });
  }
});
</script>

<template>
  <Dialog :open="isOpen">
    <DialogClose />
    <DialogTrigger as-child @click="openDialog">
      <slot />
    </DialogTrigger>
    <DialogContent
      v-on:interact-outside="closeDialog"
      v-on:close-auto-focus="closeDialog"
    >
      <DialogHeader>
        <DialogTitle>Change Fullname</DialogTitle>
        <DialogDescription>Change your fullname</DialogDescription>
      </DialogHeader>
      <form @submit.prevent="onSubmit" class="space-y-4">
        <FormField
          name="firstName"
          v-slot="{ componentField }"
          :validate-on-blur="!isFieldDirty('firstName')"
        >
          <FormItem v-auto-animate>
            <FormLabel>First Name</FormLabel>
            <FormControl>
              <Input
                type="text"
                v-bind="componentField"
                placeholder="Firstname"
              />
            </FormControl>
            <FormMessage />
          </FormItem>
        </FormField>
        <FormField
          name="lastName"
          v-slot="{ componentField }"
          :validate-on-blur="!isFieldDirty('lastName')"
        >
          <FormItem v-auto-animate>
            <FormLabel>Last Name</FormLabel>
            <FormControl>
              <Input
                type="text"
                v-bind="componentField"
                placeholder="Lastname"
              />
            </FormControl>
            <FormMessage />
          </FormItem>
        </FormField>
        <div class="flex justify-center items-center w-full">
          <Button type="submit" size="lg" class="w-full text-lg cursor-pointer">
            Save
          </Button>
        </div>
      </form>
    </DialogContent>
  </Dialog>
</template>

<style scoped></style>
