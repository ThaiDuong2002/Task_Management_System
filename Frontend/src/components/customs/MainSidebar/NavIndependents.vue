<script setup lang="ts">
import {
  SidebarGroup,
  SidebarGroupLabel,
  SidebarMenu,
  SidebarMenuButton,
  SidebarMenuItem,
} from "@/components/ui/sidebar";
import { useSelectedAssignmentStore } from "@/stores";
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
const item = useSelectedAssignmentStore();

const isActive = (url: string) => {
  return route.path === url;
};
</script>

<template>
  <SidebarGroup>
    <SidebarGroupLabel>Assignments</SidebarGroupLabel>
    <SidebarMenu>
      <SidebarMenuItem
        v-for="independency in independencies"
        :key="independency.name"
      >
        <SidebarMenuButton
          as-child
          :is-active="isActive(independency.url)"
          :tooltip="independency.name"
          @click="item.closeSidebar"
        >
          <RouterLink :to="independency.url">
            <component :is="independency.icon" v-if="independency.icon" />
            <span>{{ independency.name }}</span>
          </RouterLink>
        </SidebarMenuButton>
      </SidebarMenuItem>
    </SidebarMenu>
  </SidebarGroup>
</template>

<style scoped></style>
