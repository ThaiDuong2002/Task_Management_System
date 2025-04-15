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
  independencies: {
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
  <SidebarGroup>
    <SidebarGroupLabel>Assignments</SidebarGroupLabel>
    <SidebarMenu>
      <SidebarMenuItem v-for="item in independencies" :key="item.name">
        <SidebarMenuButton
          as-child
          :is-active="isActive(item.url)"
          :tooltip="item.name"
        >
          <RouterLink :to="item.url">
            <component :is="item.icon" v-if="item.icon" />
            <span>{{ item.name }}</span>
          </RouterLink>
        </SidebarMenuButton>
      </SidebarMenuItem>
    </SidebarMenu>
  </SidebarGroup>
</template>

<style scoped></style>
