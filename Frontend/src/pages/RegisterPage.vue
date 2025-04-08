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
import { RegisterSchema } from "@/validations";
import { useForm } from "vee-validate";

const { isFieldDirty, handleSubmit } = useForm({
  validationSchema: RegisterSchema,
});

const onSubmit = handleSubmit((values) => {
  console.log(values);
});
</script>

<template>
  <div class="flex justify-center items-center w-full h-auto min-h-screen">
    <MaxWidthWrapper class="w-full max-w-2xl h-auto">
      <Card class="my-10 py-10">
        <CardHeader>
          <CardTitle class="max-sm:text-3xl text-4xl text-center"
            >Register</CardTitle
          >
          <CardDescription class="max-sm:text-lg text-xl text-center">
            Create a new account to get started with our application.
          </CardDescription>
        </CardHeader>
        <CardContent>
          <form class="space-y-6 min-sm:px-10" @submit.prevent="onSubmit">
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
                    placeholder="Username"
                    v-bind="componentField"
                  />
                </FormControl>
                <FormMessage />
              </FormItem>
            </FormField>
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
            <div class="gap-4 grid grid-cols-2">
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
                      placeholder="First Name"
                      v-bind="componentField"
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
                      placeholder="Last Name"
                      v-bind="componentField"
                    />
                  </FormControl>
                  <FormMessage />
                </FormItem>
              </FormField>
            </div>
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
            <FormField
              name="confirmPassword"
              v-slot="{ componentField }"
              :validate-on-blur="!isFieldDirty('confirmPassword')"
            >
              <FormItem v-auto-animate>
                <FormLabel>Confirm Password</FormLabel>
                <FormControl>
                  <Input
                    type="password"
                    placeholder="Confirm Password"
                    v-bind="componentField"
                  />
                </FormControl>
                <FormMessage />
              </FormItem>
            </FormField>
            <div class="flex justify-center items-center w-full">
              <Button type="submit" size="lg" class="text-lg cursor-pointer"
                >Register</Button
              >
            </div>
          </form>
          <div class="flex flex-col justify-center items-center mt-4">
            <p class="text-gray-500 text-sm text-center">
              Already have an account?
              <router-link to="/login" class="text-blue-500 hover:underline">
                Login
              </router-link>
            </p>
          </div>
        </CardContent>
      </Card>
    </MaxWidthWrapper>
  </div>
</template>

<style lang="scss" scoped></style>
