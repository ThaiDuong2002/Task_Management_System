<script setup lang="ts">
import { DefaultLayout, MainLayout } from "@/components/layouts";
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
  <component :is="currentLayout">
    <router-view />
  </component>
</template>

<style scoped></style>
