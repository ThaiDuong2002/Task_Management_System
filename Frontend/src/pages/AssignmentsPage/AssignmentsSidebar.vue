<script setup lang="ts">
import {
  Sidebar,
  SidebarContent,
  SidebarFooter,
  SidebarHeader,
  type SidebarProps,
} from "@/components/ui/sidebar";
import { useAuthStore } from "@/stores";
import NavUser from "./NavUser.vue";

const props = withDefaults(defineProps<SidebarProps>(), {
  collapsible: "icon",
});

const auth = useAuthStore();
</script>

<template>
  <Sidebar v-bind="props">
    <SidebarHeader> <div></div></SidebarHeader>
    <SidebarContent> <div></div></SidebarContent>
    <SidebarFooter>
      <NavUser
        :user="{
          name: auth.user?.userName!,
          email: auth.user?.email!,
          avatar: 'https://www.shadcn-vue.com/avatars/shadcn.jpg' }"
      />
    </SidebarFooter>
  </Sidebar>
</template>

<style scoped></style>
