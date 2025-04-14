<script setup lang="ts">
import { DetailSidebar } from "@/components/customs/DetailSidebar";
import { MainSidebar } from "@/components/customs/MainSidebar";
import { SidebarProvider } from "@/components/ui/sidebar";
import { useSelectedAssignmentStore } from "@/stores";

const item = useSelectedAssignmentStore();
</script>

<template>
  <SidebarProvider :open="item.isSidebarOpen">
    <SidebarProvider>
      <MainSidebar />
      <slot />
    </SidebarProvider>
    <DetailSidebar />
  </SidebarProvider>
</template>

<style scoped></style>
