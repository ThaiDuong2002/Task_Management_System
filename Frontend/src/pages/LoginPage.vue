<script setup lang="ts">
import MaxWidthWrapper from "@/components/common/MaxWidthWrapper.vue";
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
import loginSchema from "@/validations/login-schema";
import { useForm } from "vee-validate";

const { isFieldDirty, handleSubmit } = useForm({
  validationSchema: loginSchema,
});

const onSubmit = handleSubmit((values) => {
  console.log(values);
});
</script>

<template>
  <div class="flex justify-center items-center w-screen h-screen">
    <MaxWidthWrapper class="w-full max-w-2xl">
      <Card class="my-10 py-10">
        <CardHeader>
          <CardTitle class="max-sm:text-3xl text-4xl text-center"
            >Login</CardTitle
          >
          <CardDescription class="max-sm:text-lg text-xl text-center"
            >Login to your account</CardDescription
          >
        </CardHeader>
        <CardContent>
          <form class="space-y-6 min-sm:px-10" @submit="onSubmit">
            <FormField
              name="email"
              v-slot="{ componentField }"
              :validate-on-blur="!isFieldDirty('email')"
            >
              <FormItem v-auto-animate>
                <FormLabel>Email</FormLabel>
                <FormControl>
                  <Input
                    type="text"
                    placeholder="Email Address"
                    v-bind="componentField"
                  />
                </FormControl>
                <FormMessage />
              </FormItem>
            </FormField>
            <FormField
              name="password"
              v-slot="{ componentField }"
              :validate-on-blur="!isFieldDirty('password')"
            >
              <FormItem v-auto-animate>
                <FormLabel>Password</FormLabel>
                <FormControl>
                  <Input
                    type="password"
                    placeholder="Password"
                    v-bind="componentField"
                  />
                </FormControl>
                <FormMessage />
              </FormItem>
            </FormField>
            <div class="flex justify-center items-center w-full">
              <Button type="submit" size="lg" class="text-lg cursor-pointer"
                >Login</Button
              >
            </div>
          </form>
          <div class="flex flex-col justify-center items-center mt-4">
            <p class="text-gray-500 text-sm text-center">
              Don't have an account?
              <router-link to="/register" class="text-blue-500 hover:underline">
                Register
              </router-link>
            </p>
          </div>
        </CardContent>
      </Card>
    </MaxWidthWrapper>
  </div>
</template>

<style lang="scss" scoped></style>
