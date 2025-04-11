<script setup lang="ts">
import { DetailSidebar } from "@/components/customs/DetailSidebar";
import { MainSidebar } from "@/components/customs/MainSidebar";
import { SidebarProvider } from "@/components/ui/sidebar";
</script>

<template>
  <SidebarProvider>
    <MainSidebar />
    <slot />
    <DetailSidebar
      :assignment="{
        id: '1',
        userId: '123',
        title: 'Important Assignment',
        description: 'This is a description of the important assignment.',
        dueDate: '2023-10-31',
        status: 'In progress',
        priority: 'High',
        createdAt: '2023-10-01',
        updatedAt: '2023-10-15',
      }"
    />
  </SidebarProvider>
</template>

<style scoped></style>
