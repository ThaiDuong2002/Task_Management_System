<script setup lang="ts">
import {
  Sidebar,
  SidebarContent,
  SidebarFooter,
  SidebarHeader,
  type SidebarProps,
} from "@/components/ui/sidebar";
import { useAuthStore } from "@/stores";
import { sidebarGroups } from "@/utils/constants";
import MainHeader from "./MainHeader.vue";
import NavDependents from "./NavDependents.vue";
import NavIndependents from "./NavIndependents.vue";
import NavUser from "./NavUser.vue";

const props = withDefaults(defineProps<SidebarProps>(), {
  collapsible: "icon",
});

const auth = useAuthStore();
const data = sidebarGroups;
</script>

<template>
  <Sidebar v-bind="props">
    <SidebarHeader>
      <MainHeader />
    </SidebarHeader>
    <SidebarContent>
      <NavIndependents :independents="data.independents" />
      <NavDependents />
    </SidebarContent>
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
