<script setup lang="ts">
import { AssignmentCard } from "@/components/customs/AssignmentCard";
import { InsetHeader } from "@/components/customs/InsetHeader";
import { SidebarInset } from "@/components/ui/sidebar";
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
    status: "Completed",
  });

  assignments.setAssignments(transformResponseToAssignments(result));
};

onMounted(fetchTodayAssignments);
</script>

<template>
  <SidebarInset>
    <InsetHeader title="Completed" />
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
