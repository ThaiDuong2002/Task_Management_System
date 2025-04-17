<script setup lang="ts">
import MainHeader from "@/components/customs/MainSidebar/MainHeader.vue";
import NavDependents from "@/components/customs/MainSidebar/NavDependents.vue";
import NavIndependents from "@/components/customs/MainSidebar/NavIndependents.vue";
import NavUser from "@/components/customs/MainSidebar/NavUser.vue";
import {
  Sidebar,
  SidebarContent,
  SidebarFooter,
  SidebarHeader,
  type SidebarProps,
} from "@/components/ui/sidebar";
import { useAuthStore } from "@/stores";
import { sidebarGroups } from "@/utils/constants";

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
      <NavIndependents :independencies="data.independencies" />
      <NavDependents :dependencies="data.dependencies" />
    </SidebarContent>
    <SidebarFooter>
      <NavUser />
    </SidebarFooter>
  </Sidebar>
</template>

<style scoped></style>
