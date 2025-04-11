<script setup lang="ts">
import { Button } from "@/components/ui/button";
import { Card } from "@/components/ui/card";
import {
  Tooltip,
  TooltipContent,
  TooltipProvider,
  TooltipTrigger,
} from "@/components/ui/tooltip";
import { cn } from "@/lib/utils";
import type { IAssignmentResponse } from "@/utils/interfaces";
import { CalendarRange, Check } from "lucide-vue-next";

defineProps<{
  assignment: IAssignmentResponse;
}>();
</script>

<template>
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
                <Check class="size-3 text-white" />
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
        <CalendarRange class="text-pink-400" />
        <p class="text-gray-500 text-sm">{{ assignment.dueDate }}</p>
      </div>
    </div>
  </Card>
</template>

<style scoped></style>
