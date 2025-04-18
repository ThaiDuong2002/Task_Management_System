<script setup lang="ts">
import { AssignmentCard } from "@/components/customs/AssignmentCard";
import { BreadcrumbHeader } from "@/components/customs/BreadcrumbHeader";
import { Separator } from "@/components/ui/separator";
import { SidebarInset, SidebarTrigger } from "@/components/ui/sidebar";
import { AssignmentService } from "@/services";
import { useAssignmentsStore, useAuthStore } from "@/stores";
import { transformResponseToAssignments } from "@/utils/mappers";
import { onMounted } from "vue";

const auth = useAuthStore();
const assignments = useAssignmentsStore();

const fetchTodayAssignments = async () => {
  const result = await AssignmentService.getAssignments({
    userId: auth.user?.id!,
    page: 1,
    limit: 10,
    status: "Completed"
  });

  assignments.setAssignments(transformResponseToAssignments(result));
};

onMounted(fetchTodayAssignments);
</script>

<template>
  <SidebarInset>
    <header
      class="flex items-center gap-2 h-16 group-has-[[data-collapsible=icon]]/sidebar-wrapper:h-12 transition-[width,height] ease-linear shrink-0"
    >
      <div class="flex items-center gap-2 px-4">
        <SidebarTrigger class="-ml-1 cursor-pointer" />
        <Separator orientation="vertical" class="mr-2 h-4" />
        <BreadcrumbHeader title="Assignments" subtitle="Completed" />
      </div>
    </header>
    <div class="flex flex-col flex-1 gap-4 bg-blue-100 p-4 pt-0">
      <div class="flex flex-col gap-2 mx-[10%] my-10 h-full">
        <AssignmentCard
          v-for="assignment in assignments.list"
          :color="'text-blue-500'"
          :assignment="assignment"
        />
      </div>
    </div>
  </SidebarInset>
</template>

<style lang="scss" scoped></style>
