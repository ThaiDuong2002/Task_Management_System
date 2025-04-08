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
  FormDescription,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "@/components/ui/form";
import { Input } from "@/components/ui/input";
import registerSchema from "@/validations/register-schema";
import { useForm } from "vee-validate";

const { isFieldDirty, handleSubmit } = useForm({
  validationSchema: registerSchema,
});

const onSubmit = handleSubmit((values) => {
  console.log(values);
});
</script>

<template>
  <div class="flex justify-center items-center w-screen h-auto min-h-screen">
    <MaxWidthWrapper class="w-full max-w-2xl h-auto">
      <Card class="my-10">
        <CardHeader>
          <CardTitle class="max-sm:text-3xl text-4xl text-center"
            >Register</CardTitle
          >
          <CardDescription class="max-sm:text-lg text-xl text-center">
            Create a new account to get started with our application.
          </CardDescription>
        </CardHeader>
        <CardContent>
          <form class="space-y-6 min-sm:px-10" @submit="onSubmit">
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
                <FormDescription>
                  This will be your unique identifier on our platform.
                </FormDescription>
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
                <FormDescription>
                  We'll never share your email with anyone else.
                </FormDescription>
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
                  <FormDescription>
                    This is the name that will be displayed on your profile.
                  </FormDescription>
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
                  <FormDescription>
                    This is the name that will be displayed on your profile.
                  </FormDescription>
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
                <FormDescription>
                  Enter a strong password to keep your account secure.
                </FormDescription>
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
                <FormDescription>
                  Please confirm your password.
                </FormDescription>
                <FormMessage />
              </FormItem>
            </FormField>
            <div class="flex justify-center items-center w-full">
              <Button type="submit" size="lg" class="text-lg cursor-pointer"
                >Register</Button
              >
            </div>
          </form>
        </CardContent>
      </Card>
    </MaxWidthWrapper>
  </div>
</template>

<style lang="scss" scoped></style>
