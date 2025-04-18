<script setup lang="ts">
import { ConfirmDialog } from "@/components/customs/ConfirmDialog";
import { Button } from "@/components/ui/button";
import { Card } from "@/components/ui/card";
import {
  ContextMenu,
  ContextMenuContent,
  ContextMenuItem,
  ContextMenuSeparator,
  ContextMenuTrigger,
} from "@/components/ui/context-menu";
import {
  Tooltip,
  TooltipContent,
  TooltipProvider,
  TooltipTrigger,
} from "@/components/ui/tooltip";
import { cn } from "@/lib/utils";
import { AssignmentService } from "@/services";
import { useAssignmentsStore, useSelectedAssignmentStore } from "@/stores";
import type { Assignment } from "@/utils/types";
import { format } from "date-fns";
import {
  AlarmClock,
  Check,
  CheckCircle2,
  CircleX,
  RefreshCcw,
  Star,
  StarOff,
  Trash2,
} from "lucide-vue-next";
import { useRoute } from "vue-router";
import { toast } from "vue-sonner";

const props = defineProps<{
  assignment: Assignment;
  color: string;
}>();

const route = useRoute();

const item = useSelectedAssignmentStore();
const assignments = useAssignmentsStore();

const handleCardClick = () => {
  item.toggleSidebar(props.assignment.id);
  item.setAssignment(props.assignment);
};

const onConfirmDelete = async () => {
  try {
    await AssignmentService.deleteAssignment(props.assignment.id);

    assignments.deleteAssignment(props.assignment.id);

    item.closeSidebar();

    toast.success("Assignment deleted successfully", {
      description: "Assignment deleted successfully",
    });
  } catch (error) {
    toast.error("Failed to delete assignment", {
      description: "Please try again later",
    });
  }
};

const handleComplete = async () => {
  try {
    await AssignmentService.updateAssignment(props.assignment.id, {
      status: "Completed",
    });

    assignments.deleteAssignment(props.assignment.id);

    toast.success("Assignment completed successfully", {
      description: "Assignment completed successfully",
    });
  } catch (error) {
    toast.error("Failed to complete assignment", {
      description: "Please try again later",
    });
  }
};
const handleInProgress = async () => {
  try {
    await AssignmentService.updateAssignment(props.assignment.id, {
      status: "In progress",
    });

    if (route.path === "/assignments/completed") {
      assignments.deleteAssignment(props.assignment.id);
    }

    assignments.updateAssignment({
      ...props.assignment,
      status: "In progress",
    });

    toast.success("Assignment in progress successfully", {
      description: "Assignment in progress successfully",
    });
  } catch (error) {
    toast.error("Failed to in progress assignment", {
      description: "Please try again later",
    });
  }
};

const handleImportant = async () => {
  try {
    await AssignmentService.updateAssignment(props.assignment.id, {
      priority: "High",
    });

    assignments.updateAssignment({
      ...props.assignment,
      priority: "High",
    });

    toast.success("Assignment marked as important successfully", {
      description: "Assignment marked as important successfully",
    });
  } catch (error) {
    toast.error("Failed to mark assignment as important", {
      description: "Please try again later",
    });
  }
};

const handleNotImportant = async () => {
  try {
    await AssignmentService.updateAssignment(props.assignment.id, {
      priority: "Medium",
    });

    if (route.path === "/assignments/important") {
      assignments.deleteAssignment(props.assignment.id);
    }

    assignments.updateAssignment({
      ...props.assignment,
      priority: "Medium",
    });

    toast.success("Assignment marked as not important successfully", {
      description: "Assignment marked as not important successfully",
    });
  } catch (error) {
    toast.error("Failed to mark assignment as not important", {
      description: "Please try again later",
    });
  }
};
</script>

<template>
  <ContextMenu>
    <ContextMenuTrigger>
      <Card
        :class="
          cn(
            'hover:bg-gray-50 shadow-none p-0.5 border-0 cursor-pointer',
            assignment.priority === 'High' ? 'border-2 border-red-500' : ''
          )
        "
        @click="handleCardClick"
      >
        <div class="flex justify-between items-center p-4">
          <div class="flex items-center gap-4">
            <TooltipProvider>
              <Tooltip>
                <TooltipTrigger>
                  <Button
                    size="sm"
                    variant="default"
                    :class="
                      cn('rounded-full cursor-pointer', {
                        'bg-blue-500': assignment.status === 'Completed',
                        'bg-green-500': assignment.status === 'In progress',
                      })
                    "
                    @click.stop="
                      assignment.status === 'Completed'
                        ? handleInProgress()
                        : handleComplete()
                    "
                  >
                    <Check
                      v-if="assignment.status === 'Completed'"
                      class="size-3 text-white"
                    />
                    <RefreshCcw
                      v-if="assignment.status === 'In progress'"
                      class="size-3 text-white"
                    />
                  </Button>
                </TooltipTrigger>
                <TooltipContent>
                  <p>{{ assignment.status }}</p>
                </TooltipContent>
              </Tooltip>
            </TooltipProvider>
            <p class="text-base">{{ assignment.title }}</p>
          </div>
          <div class="flex flex-row items-center gap-2">
            <AlarmClock :class="color" />
            <p class="text-gray-500 text-sm">
              {{
                route.path === "/assignments/today"
                  ? format(assignment.dueDate, "HH:mm a")
                  : format(assignment.dueDate, "dd/MM/yyyy, HH:mm a")
              }}
            </p>
          </div>
        </div>
      </Card>
    </ContextMenuTrigger>
    <ContextMenuContent>
      <ContextMenuItem
        @click="
          assignment.status == 'Completed'
            ? handleInProgress()
            : handleComplete()
        "
      >
        <CheckCircle2 class="mr-1" v-if="assignment.status !== 'Completed'" />
        <CircleX class="mr-1" v-else />
        {{
          assignment.status === "Completed"
            ? "Mark as Not Completed"
            : "Mark as Completed"
        }}
      </ContextMenuItem>
      <ContextMenuItem
        @click="
          assignment.priority == 'High'
            ? handleNotImportant()
            : handleImportant()
        "
      >
        <Star class="mr-1" v-if="assignment.priority !== 'High'" />
        <StarOff class="mr-1" v-else />
        {{
          assignment.priority === "High"
            ? "Mark as Not Important"
            : "Mark as Important"
        }}
      </ContextMenuItem>
      <ContextMenuSeparator />
      <ConfirmDialog
        title="Are you absolutely sure?"
        message="This action will permanently delete this assignment and cannot be undone."
        confirmText="Delete"
        cancelText="Cancel"
        :onConfirm="onConfirmDelete"
      >
        <ContextMenuItem @select.prevent>
          <Trash2 class="mr-1 text-red-500" />
          <p class="text-red-500">Delete</p>
        </ContextMenuItem>
      </ConfirmDialog>
    </ContextMenuContent>
  </ContextMenu>
</template>

<style scoped></style>
