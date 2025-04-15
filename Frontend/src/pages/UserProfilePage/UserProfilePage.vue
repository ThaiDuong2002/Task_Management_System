<script setup lang="ts">
import { BreadcrumbHeader } from "@/components/customs/BreadcrumbHeader";
import { Separator } from "@/components/ui/separator";
import { SidebarInset, SidebarTrigger } from "@/components/ui/sidebar";
import { Tabs, TabsContent, TabsList, TabsTrigger } from "@/components/ui/tabs";
import { ChangePasswordTab } from "@/pages/UserProfilePage/ChangePasswordTab";
import { ProfileTab } from "@/pages/UserProfilePage/ProfileTab";
</script>

<template>
  <SidebarInset>
    <header
      class="sticky flex items-center gap-2 h-16 group-has-[[data-collapsible=icon]]/sidebar-wrapper:h-12 transition-[width,height] ease-linear shrink-0"
    >
      <div class="flex items-center gap-2 px-4">
        <SidebarTrigger class="-ml-1 cursor-pointer" />
        <Separator orientation="vertical" class="mr-2 h-4" />
        <BreadcrumbHeader title="User Profile" />
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
            <ProfileTab />
          </TabsContent>
          <TabsContent value="password">
            <ChangePasswordTab />
          </TabsContent>
        </Tabs>
      </div>
    </div>
  </SidebarInset>
</template>

<style scoped></style>
