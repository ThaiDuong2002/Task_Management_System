<script setup lang="ts">
import { MainSidebar } from "@/components/customs/MainSidebar";
import { DefaultLayout, MainLayout } from "@/components/layouts";
import { SidebarProvider } from "@/components/ui/sidebar";
import { computed } from "vue";
import { useRoute } from "vue-router";

const route = useRoute();

const currentLayout = computed(() => {
  if (route.meta.layout === "default") {
    return DefaultLayout;
  } else {
    return MainLayout;
  }
});
</script>

<template>
  <component :is="currentLayout">
    <router-view />
  </component>
</template>

<style scoped></style>
