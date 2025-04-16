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
import { UserService } from "@/services";
import { useAuthStore } from "@/stores";
import UsernameSchema from "@/validations/UsernameSchema";
import { useForm, useSetFormErrors } from "vee-validate";

const { isFieldDirty, handleSubmit } = useForm({
  initialValues: {
    username: "",
  },
  validationSchema: UsernameSchema,
});

const setError = useSetFormErrors();
const auth = useAuthStore();

const onSubmit = handleSubmit(async (values) => {
  const { username } = values;

  try {
    await UserService.updateUser({
      userName: username,
    });

    auth.setUser({ userName: username });
  } catch (error: any) {
    setError({ username: error.message });
  }
});
</script>

<template>
  <Dialog>
    <DialogTrigger as-child>
      <slot />
    </DialogTrigger>
    <DialogContent>
      <DialogHeader>
        <DialogTitle>Change Username</DialogTitle>
        <DialogDescription>Change your username</DialogDescription>
      </DialogHeader>
      <form @submit.prevent="onSubmit" class="space-y-4">
        <FormField
          name="username"
          v-slot="{ componentField }"
          :validate-on-blur="!isFieldDirty('username')"
        >
          <FormItem v-auto-animate>
            <FormLabel>Username</FormLabel>
            <FormControl>
              <Input
                type="text"
                v-bind="componentField"
                placeholder="Username"
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
