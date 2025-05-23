<script setup lang="ts">
import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar";
import { Button } from "@/components/ui/button";
import { Card, CardHeader } from "@/components/ui/card";
import { Separator } from "@/components/ui/separator";
import ImageDialog from "@/pages/UserProfilePage/ProfileTab/ImageDialog.vue";
import { useAuthStore } from "@/stores";
import FullnameDialog from "./FullnameDialog.vue";
import UsernameDialog from "./UsernameDialog.vue";

const auth = useAuthStore();
</script>

<template>
  <Card>
    <CardHeader>
      <div class="flex flex-row justify-start items-center gap-5">
        <Avatar class="mb-4 w-40 h-40">
          <AvatarImage
            :src="auth.user?.imageUrl || ''"
            :alt="auth.user?.userName"
          />
          <AvatarFallback>
            {{ auth.user?.userName.substring(0, 2).toUpperCase() }}
          </AvatarFallback>
        </Avatar>
        <div class="flex flex-col justify-center items-start gap-2">
          <p class="max-w-sm">
            Customize your account by adding a profile photo. This image will be
            displayed on apps and devices that utilize your account.
          </p>
          <ImageDialog>
            <Button variant="outline" class="cursor-pointer">
              Change Photo
            </Button>
          </ImageDialog>
        </div>
      </div>
      <Separator class="mb-4" />
      <div class="flex flex-row justify-between items-center gap-2">
        <div class="text-muted-foreground">Email</div>
        <div>{{ auth.user?.email }}</div>
      </div>
    </CardHeader>
  </Card>
  <Card class="mt-2.5">
    <CardHeader>
      <div class="flex flex-col gap-4">
        <div class="items-center gap-4 grid grid-cols-3">
          <div class="gap-4 grid grid-cols-2 col-span-2">
            <div class="text-muted-foreground text-start">Username</div>
            <div class="text-start">{{ auth.user?.userName }}</div>
          </div>
          <div class="flex flex-row justify-end items-center gap-2">
            <UsernameDialog>
              <Button
                variant="ghost"
                class="hover:bg-white w-auto text-blue-400 hover:text-blue-600 hover:underline cursor-pointer"
              >
                Edit username
              </Button>
            </UsernameDialog>
          </div>
        </div>
        <div class="items-center gap-4 grid grid-cols-3">
          <div class="gap-4 grid grid-cols-2 col-span-2">
            <div class="text-muted-foreground text-start">Fullname</div>
            <div class="text-start">
              {{ auth.user?.firstName }} {{ auth.user?.lastName }}
            </div>
          </div>
          <div class="flex flex-row justify-end items-center gap-2">
            <FullnameDialog>
              <Button
                variant="ghost"
                class="hover:bg-white text-blue-400 hover:text-blue-600 hover:underline cursor-pointer"
              >
                Edit fullname
              </Button>
            </FullnameDialog>
          </div>
        </div>
      </div>
    </CardHeader>
  </Card>
</template>

<style scoped></style>
