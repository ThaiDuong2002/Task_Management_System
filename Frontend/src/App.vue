<script setup lang="ts">
import { DefaultLayout, MainLayout } from "@/components/layouts";
import { Toaster } from "@/components/ui/sonner";
import { computed } from "vue";
import { useRoute } from "vue-router";

const route = useRoute();

const currentLayout = computed(() => {
  if (route.meta.layout === "main") {
    return MainLayout;
  } else {
    return DefaultLayout;
  }
});
</script>

<template>
  <Toaster class="pointer-events-auto" />
  <component :is="currentLayout">
    <router-view />
  </component>
</template>

<style scoped></style>
