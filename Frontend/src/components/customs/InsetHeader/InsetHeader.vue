<script setup lang="ts">
import { BreadcrumbHeader } from "@/components/customs/BreadcrumbHeader";
import { Button } from "@/components/ui/button";
import { Separator } from "@/components/ui/separator";
import { SidebarTrigger } from "@/components/ui/sidebar";
import { AssignmentService } from "@/services";
import { useAssignmentsStore, useAuthStore } from "@/stores";
import { transformResponseToAssignment } from "@/utils/mappers";
import { useRoute } from "vue-router";
import { toast } from "vue-sonner";

defineProps<{
  title: string;
  subtitle?: string;
}>();

const route = useRoute();
const assignments = useAssignmentsStore();
const auth = useAuthStore();

const handleAdd = async () => {
  try {
    const result = await AssignmentService.createAssignment({
      userId: auth.user?.id!,
      title: "New Assignment",
    });

    assignments.addAssignment(transformResponseToAssignment(result));
  } catch (error: any) {
    toast.error("Failed to create assignment", {
      description: error.message,
    });
  }
};
</script>

<template>
  <header
    class="flex justify-between items-center gap-2 mx-2 h-16 group-has-[[data-collapsible=icon]]/sidebar-wrapper:h-12 transition-[width,height] ease-linear shrink-0"
  >
    <div class="flex items-center gap-2 px-4">
      <SidebarTrigger class="-ml-1 cursor-pointer" />
      <Separator orientation="vertical" class="mr-2 h-4" />
      <BreadcrumbHeader :title="title" :subtitle="subtitle" />
    </div>
    <div
      v-if="
        route.path !== '/assignments/completed' &&
        route.path !== '/assignments/overdue'
      "
    >
      <Button class="cursor-pointer" variant="outline" @click="handleAdd">
        <span class="font-medium text-sm">Add</span>
      </Button>
    </div>
  </header>
</template>

<style scoped></style>
