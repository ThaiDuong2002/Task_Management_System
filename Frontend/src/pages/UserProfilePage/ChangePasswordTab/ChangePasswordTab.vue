<script setup lang="ts">
import { Button } from "@/components/ui/button";
import {
  Card,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import {
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "@/components/ui/form";
import { Input } from "@/components/ui/input";
import { UserService } from "@/services";
import InvalidPasswordException from "@/utils/exceptions/InvalidPasswordException";
import ChangePasswordSchema from "@/validations/ChangePasswordSchema";
import { useForm, useSetFormErrors } from "vee-validate";

const { isFieldDirty, handleSubmit } = useForm({
  validationSchema: ChangePasswordSchema,
});

const setError = useSetFormErrors();

const onSubmit = handleSubmit(async (values) => {
  const { oldPassword, newPassword } = values;
  try {
    await UserService.changePassword({
      oldPassword,
      newPassword,
    });
  } catch (error: any) {
    if (error instanceof InvalidPasswordException) {
      setError({
        oldPassword: error.message,
      });
    } else {
      setError({
        confirmPassword: error.message,
      });
    }
  }
});
</script>

<template>
  <Card class="px-30">
    <CardHeader>
      <CardTitle class="text-2xl text-center">Change Password</CardTitle>
      <CardDescription class="text-xl text-center"
        >Change your password</CardDescription
      >
    </CardHeader>
    <CardContent>
      <form class="space-y-6" @submit.prevent="onSubmit">
        <FormField
          name="oldPassword"
          v-slot="{ componentField }"
          :validate-on-blur="!isFieldDirty('oldPassword')"
        >
          <FormItem v-auto-animate>
            <FormLabel> Old Password </FormLabel>
            <FormControl>
              <Input type="password" v-bind="componentField" />
            </FormControl>
            <FormMessage />
          </FormItem>
        </FormField>
        <FormField
          name="newPassword"
          v-slot="{ componentField }"
          :validate-on-blur="!isFieldDirty('newPassword')"
        >
          <FormItem v-auto-animate>
            <FormLabel> New Password </FormLabel>
            <FormControl>
              <Input type="password" v-bind="componentField" />
            </FormControl>
            <FormMessage />
          </FormItem>
        </FormField>
        <FormField
          name="confirmPassword"
          v-slot="{ componentField }"
          :validate-on-blur="!isFieldDirty('confirmPassword')"
        >
          <FormItem v-auto-animate>
            <FormLabel> Confirm Password </FormLabel>
            <FormControl>
              <Input type="password" v-bind="componentField" />
            </FormControl>
            <FormMessage />
          </FormItem>
        </FormField>
        <div class="flex justify-center items-center w-full">
          <Button type="submit" size="lg" class="text-lg cursor-pointer">
            Change Password
          </Button>
        </div>
      </form>
    </CardContent>
  </Card>
</template>

<style scoped></style>
