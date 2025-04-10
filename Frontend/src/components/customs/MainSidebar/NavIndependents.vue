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

defineProps<{
  independents: {
    name: string;
    icon: FunctionalComponent<LucideProps, {}, any, {}>;
    url: string;
  }[];
}>();
</script>

<template>
  <SidebarGroup class="group-data-[collapsible=icon]:hidden">
    <SidebarGroupLabel>Assignments</SidebarGroupLabel>
    <SidebarMenu>
      <SidebarMenuItem v-for="item in independents" :key="item.name">
        <SidebarMenuButton as-child>
          <a :href="item.url">
            <component :is="item.icon" />
            <span>{{ item.name }}</span>
          </a>
        </SidebarMenuButton>
      </SidebarMenuItem>
    </SidebarMenu>
  </SidebarGroup>
</template>

<style scoped></style>
