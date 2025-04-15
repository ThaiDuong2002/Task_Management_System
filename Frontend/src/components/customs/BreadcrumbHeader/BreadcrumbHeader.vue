<script setup lang="ts">
import {
  Breadcrumb,
  BreadcrumbItem,
  BreadcrumbList,
  BreadcrumbPage,
  BreadcrumbSeparator,
} from "@/components/ui/breadcrumb";

defineProps<{
  title: string;
  subtitle?: string;
}>();
</script>

<template>
  <Breadcrumb>
    <BreadcrumbList>
      <BreadcrumbItem>
        <BreadcrumbPage>{{ title }}</BreadcrumbPage>
      </BreadcrumbItem>
      <BreadcrumbSeparator class="hidden md:block" v-if="subtitle" />
      <BreadcrumbItem v-if="subtitle">
        <BreadcrumbPage>{{ subtitle }}</BreadcrumbPage>
      </BreadcrumbItem>
    </BreadcrumbList>
  </Breadcrumb>
</template>

<style scoped></style>
