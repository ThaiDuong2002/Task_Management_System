<script setup lang="ts">
import { AssignmentCard } from "@/components/customs/AssignmentCard";
import { BreadcrumbHeader } from "@/components/customs/BreadcrumbHeader";
import { InsetHeader } from "@/components/customs/InsetHeader";
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
    options: "overdue",
  });

  assignments.setAssignments(transformResponseToAssignments(result));
};

onMounted(fetchTodayAssignments);
</script>

<template>
  <SidebarInset>
    <InsetHeader title="Overdue" />
    <div class="flex flex-col flex-1 gap-4 bg-amber-100 p-4 pt-0">
      <div class="flex flex-col gap-2 mx-[10%] my-10 h-full">
        <AssignmentCard
          v-for="assignment in assignments.list"
          :color="'text-amber-500'"
          :assignment="assignment"
        />
      </div>
    </div>
  </SidebarInset>
</template>

<style lang="scss" scoped></style>
