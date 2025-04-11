<script setup lang="ts">
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
import type { IAssignmentResponse } from "@/utils/interfaces";
import {
  CalendarRange,
  Check,
  CheckCircle2,
  Edit2,
  ListChecks,
  RefreshCcw,
  Star,
  Trash2,
} from "lucide-vue-next";
import ConfirmDialog from "../ConfirmDialog/ConfirmDialog.vue";

defineProps<{
  assignment: IAssignmentResponse;
  color: string;
}>();
</script>

<template>
  <ContextMenu>
    <ContextMenuTrigger>
      <Card class="hover:bg-gray-50 shadow-none p-0.5 border-0 cursor-pointer">
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
                        'bg-amber-500': assignment.status === 'Pending',
                      })
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
                    <ListChecks
                      v-if="assignment.status === 'Pending'"
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
            <CalendarRange :class="color" />
            <p class="text-gray-500 text-sm">{{ assignment.dueDate }}</p>
          </div>
        </div>
      </Card>
    </ContextMenuTrigger>
    <ContextMenuContent>
      <ContextMenuItem>
        <CheckCircle2 class="mr-1" />
        Mark as Completed
      </ContextMenuItem>
      <ContextMenuItem>
        <Star class="mr-1" />
        Mark as Important
      </ContextMenuItem>
      <ContextMenuSeparator />
      <ConfirmDialog
        title="Are you absolutely sure?"
        message="This action will permanently delete this assignment and cannot be undone."
        confirmText="Delete"
        cancelText="Cancel"
        :onConfirm="() => console.log('Confirmed')"
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
