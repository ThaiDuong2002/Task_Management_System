<script setup lang="ts">
import {
  SidebarGroup,
  SidebarGroupLabel,
  SidebarMenu,
  SidebarMenuButton,
  SidebarMenuItem,
} from "@/components/ui/sidebar";
import type { LucideProps } from "lucide-vue-next";
import type { FunctionalComponent } from "vue";
import { useRoute } from "vue-router";

defineProps<{
  dependencies: {
    name: string;
    icon: FunctionalComponent<LucideProps, {}, any, {}>;
    url: string;
  }[];
}>();

const route = useRoute();

const isActive = (url: string) => {
  return route.path === url;
};
</script>

<template>
  <SidebarGroup class="group-data-[collapsible=icon]:hidden">
    <SidebarGroupLabel>Group Assignments</SidebarGroupLabel>
    <SidebarMenu>
      <SidebarMenuItem v-for="item in dependencies" :key="item.name">
        <SidebarMenuButton as-child :is-active="isActive(item.url)">
          <RouterLink :to="item.url">
            <component :is="item.icon" />
            <span>{{ item.name }}</span>
          </RouterLink>
        </SidebarMenuButton>
      </SidebarMenuItem>
    </SidebarMenu>
  </SidebarGroup>
</template>

<style scoped></style>
