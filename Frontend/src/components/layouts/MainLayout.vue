<script setup lang="ts">
import { DetailSidebar } from "@/components/customs/DetailSidebar";
import { MainSidebar } from "@/components/customs/MainSidebar";
import { SidebarProvider } from "@/components/ui/sidebar";
</script>

<template>
  <SidebarProvider>
    <MainSidebar />
    <slot />
  </SidebarProvider>
  <SidebarProvider :open="true">
    <DetailSidebar />
  </SidebarProvider>
</template>

<style scoped></style>
