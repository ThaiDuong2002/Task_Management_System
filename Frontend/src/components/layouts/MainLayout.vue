<script setup lang="ts">
import { MainSidebar } from "@/components/customs/MainSidebar";
import { SidebarProvider } from "@/components/ui/sidebar";
</script>

<template>
  <SidebarProvider>
    <MainSidebar />
    <slot />
  </SidebarProvider>
</template>

<style scoped></style>
