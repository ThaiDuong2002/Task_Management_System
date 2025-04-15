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
  FormLabel,
  FormMessage,
} from "@/components/ui/form";
import { Input } from "@/components/ui/input";
import FullnameSchema from "@/validations/FullnameSchema";
import { useForm } from "vee-validate";

const { isFieldDirty, handleSubmit } = useForm({
  initialValues: {
    firstName: "",
    lastName: "",
  },
  validationSchema: FullnameSchema,
});

const onSubmit = handleSubmit((values) => {
  console.log(values);
});
</script>

<template>
  <Dialog>
    <DialogTrigger as-child>
      <slot />
    </DialogTrigger>
    <DialogContent>
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
