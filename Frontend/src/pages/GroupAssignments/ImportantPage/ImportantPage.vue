<script setup lang="ts">
import { BreadcrumbHeader } from "@/components/customs/BreadcrumbHeader";
import { Separator } from "@/components/ui/separator";
import { SidebarInset, SidebarTrigger } from "@/components/ui/sidebar";
</script>

<template>
  <SidebarInset>
    <header
      class="flex items-center gap-2 h-16 group-has-[[data-collapsible=icon]]/sidebar-wrapper:h-12 transition-[width,height] ease-linear shrink-0"
    >
      <div class="flex items-center gap-2 px-4">
        <SidebarTrigger class="-ml-1 cursor-pointer" />
        <Separator orientation="vertical" class="mr-2 h-4" />
        <BreadcrumbHeader title="Group Assignments" subtitle="Important" />
      </div>
    </header>
    <div class="flex flex-col flex-1 gap-4 bg-pink-100 p-4 pt-0"></div>
  </SidebarInset>
</template>

<style lang="scss" scoped></style>
