<script setup lang="ts">
import { BreadcrumbHeader } from "@/components/customs/BreadcrumbHeader";
import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar";
import { Button } from "@/components/ui/button";
import { Card, CardHeader } from "@/components/ui/card";
import { Separator } from "@/components/ui/separator";
import { SidebarInset, SidebarTrigger } from "@/components/ui/sidebar";
import { Tabs, TabsContent, TabsList, TabsTrigger } from "@/components/ui/tabs";
import { useAuthStore } from "@/stores";

const auth = useAuthStore();
</script>

<template>
  <SidebarInset>
    <header
      class="sticky flex items-center gap-2 h-16 group-has-[[data-collapsible=icon]]/sidebar-wrapper:h-12 transition-[width,height] ease-linear shrink-0"
    >
      <div class="flex items-center gap-2 px-4">
        <SidebarTrigger class="-ml-1 cursor-pointer" />
        <Separator orientation="vertical" class="mr-2 h-4" />
        <BreadcrumbHeader title="Group Assignments" subtitle="Completed" />
      </div>
    </header>
    <div class="flex flex-col flex-1 gap-4 bg-gray-50 p-4 pt-0">
      <div class="flex flex-col gap-2 mx-[15%] my-10 h-full">
        <Tabs default-value="profile">
          <TabsList class="grid grid-cols-2 w-full">
            <TabsTrigger value="profile" class="cursor-pointer">
              Profile
            </TabsTrigger>
            <TabsTrigger value="password" class="cursor-pointer">
              Change Password
            </TabsTrigger>
          </TabsList>
          <TabsContent value="profile">
            <Card>
              <CardHeader>
                <div class="flex flex-row justify-start items-center gap-5">
                  <Avatar class="mb-4 w-40 h-40">
                    <AvatarImage
                      src="https://www.shadcn-vue.com/avatars/shadcn.jpg"
                      alt="User Avatar"
                    />
                    <AvatarFallback>
                      {{ auth.user?.userName.substring(0, 2).toUpperCase() }}
                    </AvatarFallback>
                  </Avatar>
                  <div class="flex flex-col justify-center items-start gap-2">
                    <p class="max-w-sm">
                      Customize your account by adding a profile photo. This
                      image will be displayed on apps and devices that utilize
                      your account.
                    </p>
                    <Button variant="outline" class="cursor-pointer">
                      Change Photo
                    </Button>
                  </div>
                </div>
                <Separator class="mb-4" />
                <div class="flex flex-row justify-between items-center gap-2">
                  <div class="text-muted-foreground">Email</div>
                  <div>{{ auth.user?.email }}</div>
                </div>
              </CardHeader>
            </Card>
            <Card class="mt-2">
              <CardHeader>
                <div class="flex flex-col gap-4">
                  <div class="items-center gap-4 grid grid-cols-2">
                    <div class="gap-4 grid grid-cols-2">
                      <div class="text-muted-foreground text-start">
                        Username
                      </div>
                      <div class="text-start">{{ auth.user?.userName }}</div>
                    </div>
                    <div class="flex flex-row justify-end items-center gap-2">
                      <Button
                        variant="ghost"
                        class="hover:bg-white text-blue-400 hover:text-blue-600 hover:underline cursor-pointer"
                      >
                        Edit username
                      </Button>
                    </div>
                  </div>
                  <div class="items-center gap-4 grid grid-cols-2">
                    <div class="gap-4 grid grid-cols-2">
                      <div class="text-muted-foreground text-start">
                        Display Name
                      </div>
                      <div class="text-start">
                        {{ auth.user?.firstName }} {{ auth.user?.lastName }}
                      </div>
                    </div>
                    <div class="flex flex-row justify-end items-center gap-2">
                      <Button
                        variant="ghost"
                        class="hover:bg-white text-blue-400 hover:text-blue-600 hover:underline cursor-pointer"
                      >
                        Edit Display Name
                      </Button>
                    </div>
                  </div>
                </div>
              </CardHeader>
            </Card>
          </TabsContent>
          <TabsContent value="password"></TabsContent>
        </Tabs>
      </div>
    </div>
  </SidebarInset>
</template>

<style scoped></style>
