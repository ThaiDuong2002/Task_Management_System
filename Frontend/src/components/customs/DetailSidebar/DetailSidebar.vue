<script setup lang="ts">
import { DatetimePicker } from "@/components/customs/DatetimePicker";
import { Button } from "@/components/ui/button";
import { Card } from "@/components/ui/card";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import {
  Popover,
  PopoverContent,
  PopoverTrigger,
} from "@/components/ui/popover";
import {
  Sidebar,
  SidebarContent,
  SidebarFooter,
  SidebarHeader,
  SidebarSeparator,
  type SidebarProps,
} from "@/components/ui/sidebar";
import { Textarea } from "@/components/ui/textarea";
import { cn } from "@/lib/utils";
import { AssignmentService } from "@/services";
import { useAssignmentsStore, useSelectedAssignmentStore } from "@/stores";
import { isSameDate } from "@/utils/functions";
import { format } from "date-fns";
import {
  CalendarIcon,
  CheckCircle2,
  CircleX,
  PanelRightClose,
  Star,
  StarOff,
} from "lucide-vue-next";
import { ref } from "vue";
import { useRoute } from "vue-router";
import { toast } from "vue-sonner";

const props = withDefaults(defineProps<SidebarProps>(), {
  collapsible: "offcanvas",
  side: "right",
});

const placeholder = ref();
const route = useRoute();
const item = useSelectedAssignmentStore();
const assignments = useAssignmentsStore();

const closeSidebar = () => {
  item.closeSidebar();
};

const handleComplete = async () => {
  try {
    await AssignmentService.updateAssignment(item.assignment.id, {
      status: "Completed",
    });

    assignments.deleteAssignment(item.assignment.id);

    item.closeSidebar();

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
    await AssignmentService.updateAssignment(item.assignment.id, {
      status: "In progress",
    });

    if (route.path === "/assignments/completed") {
      assignments.deleteAssignment(item.assignment.id);
    }

    item.closeSidebar();

    assignments.updateAssignment({
      ...item.assignment,
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
    await AssignmentService.updateAssignment(item.assignment.id, {
      priority: "High",
    });

    assignments.updateAssignment({
      ...item.assignment,
      priority: "High",
    });

    item.setAssignment({
      ...item.assignment,
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
    await AssignmentService.updateAssignment(item.assignment.id, {
      priority: "Medium",
    });

    if (route.path === "/assignments/important") {
      assignments.deleteAssignment(item.assignment.id);
    }

    assignments.updateAssignment({
      ...item.assignment,
      priority: "Medium",
    });

    item.setAssignment({
      ...item.assignment,
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

const handleSave = async () => {
  if (!item.assignment.title || item.assignment.dueDate < new Date()) {
    return;
  }

  try {
    await AssignmentService.updateAssignment(item.assignment.id, {
      title: item.assignment.title,
      description: item.assignment.description,
      dueDate: item.assignment.dueDate.toISOString(),
    });
    
    if (
      route.path === "/assignments/today" &&
      isSameDate(item.assignment.dueDate, new Date())
    ) {
      assignments.updateAssignment(item.assignment);
    } else {
      assignments.deleteAssignment(item.assignment.id);
    }

    toast.success("Assignment updated successfully", {
      description: "Assignment updated successfully",
    });
  } catch (error: any) {
    toast.error("Failed to update assignment", {
      description: error.message,
    });
  }
};
</script>

<template>
  <Sidebar v-bind="props">
    <SidebarHeader class="flex justify-between items-end p-2">
      <Button
        size="icon"
        variant="ghost"
        class="rounded-full cursor-pointer"
        @click="closeSidebar"
      >
        <PanelRightClose class="w-5 h-5" />
      </Button>
    </SidebarHeader>
    <SidebarContent class="p-2">
      <Card class="shadow-none p-2 rounded-sm">
        <p
          v-if="item.assignment.title.length === 0"
          class="text-destructive text-sm"
        >
          Title is required
        </p>
        <Input
          v-model="item.assignment.title"
          placeholder="Enter title here"
          class="shadow-none border-0 active:border-0 focus-visible:outline-none focus-visible:ring-0"
        />
      </Card>
      <Card class="shadow-none p-2 rounded-sm">
        <Label for="description">Description</Label>
        <Textarea
          v-model="item.assignment.description"
          placeholder="Enter description here"
          class="shadow-none border-0 active:border-0 focus-visible:outline-none focus-visible:ring-0 resize-none"
        />
        <SidebarSeparator class="m-0 p-0" />
        <p
          v-if="item.assignment.dueDate < new Date()"
          class="text-destructive text-sm"
        >
          Due date must be in the future
        </p>
        <Popover>
          <PopoverTrigger as-child>
            <Button
              variant="outline"
              :class="
                cn('ps-3 font-normal text-start', 'text-muted-foreground')
              "
            >
              <span>{{
                format(item.assignment.dueDate, "dd/MM/yyyy, HH:mm a") ||
                "Pick a date"
              }}</span>
              <CalendarIcon class="opacity-50 ms-auto w-4 h-4" />
            </Button>
          </PopoverTrigger>
          <PopoverContent class="p-0 w-auto">
            <!-- <Calendar calendar-label="Date of birth" initial-focus /> -->
            <DatetimePicker v-model="item.assignment.dueDate" initial-focus />
          </PopoverContent>
        </Popover>
      </Card>
      <Card class="gap-1 shadow-none p-2 rounded-sm">
        <Button
          variant="ghost"
          class="cursor-pointer"
          size="sm"
          @click="
            item.assignment.status === 'Completed'
              ? handleInProgress()
              : handleComplete()
          "
        >
          <CheckCircle2
            class="mr-1"
            v-if="item.assignment.status !== 'Completed'"
          />
          <CircleX class="mr-1" v-else />
          {{
            item.assignment.status === "Completed"
              ? "Mark as Not Completed"
              : "Mark as Completed"
          }}
        </Button>
        <Button
          variant="ghost"
          class="cursor-pointer"
          size="sm"
          @click="
            item.assignment.priority == 'High'
              ? handleNotImportant()
              : handleImportant()
          "
        >
          <Star class="mr-1" v-if="item.assignment.priority !== 'High'" />
          <StarOff class="mr-1" v-else />
          {{
            item.assignment.priority === "High"
              ? "Mark as Not Important"
              : "Mark as Important"
          }}
        </Button>
      </Card>
    </SidebarContent>
    <SidebarFooter>
      <Button size="sm" class="w-full cursor-pointer" @click="handleSave"
        >Save</Button
      >
    </SidebarFooter>
  </Sidebar>
</template>

<style scoped></style>
