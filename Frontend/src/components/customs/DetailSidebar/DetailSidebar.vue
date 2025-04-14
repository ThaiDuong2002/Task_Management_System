<script setup lang="ts">
import { Button } from "@/components/ui/button";
import { Calendar } from "@/components/ui/calendar";
import { Card } from "@/components/ui/card";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import {
  Popover,
  PopoverContent,
  PopoverTrigger,
} from "@/components/ui/popover";
import {
  Select,
  SelectContent,
  SelectGroup,
  SelectItem,
  SelectLabel,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";
import {
  Sidebar,
  SidebarContent,
  SidebarHeader,
  SidebarSeparator,
  type SidebarProps,
} from "@/components/ui/sidebar";
import { Textarea } from "@/components/ui/textarea";
import { cn } from "@/lib/utils";
import { useSelectedAssignmentStore } from "@/stores";
import { CalendarIcon } from "lucide-vue-next";
import { ref } from "vue";

const props = withDefaults(defineProps<SidebarProps>(), {
  collapsible: "offcanvas",
  side: "right",
});

const placeholder = ref();
const item = useSelectedAssignmentStore();
</script>

<template>
  <Sidebar v-bind="props">
    <SidebarHeader>
      <Card class="shadow-none p-2 rounded-sm">
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
        <Popover>
          <PopoverTrigger as-child>
            <Button
              variant="outline"
              :class="
                cn('ps-3 font-normal text-start', 'text-muted-foreground')
              "
            >
              <span>{{ "Pick a date" }}</span>
              <CalendarIcon class="opacity-50 ms-auto w-4 h-4" />
            </Button>
          </PopoverTrigger>
          <PopoverContent class="p-0 w-auto">
            <Calendar
              v-model:placeholder="placeholder"
              calendar-label="Date of birth"
              initial-focus
            />
          </PopoverContent>
        </Popover>
        <SidebarSeparator class="m-0 p-0" />
        <Label for="status">Status</Label>
        <Select>
          <SelectTrigger class="w-full">
            <SelectValue placeholder="Select status" />
          </SelectTrigger>
          <SelectContent>
            <SelectLabel>Choose a status</SelectLabel>
            <SelectGroup>
              <SelectItem value="In progress">In Progress</SelectItem>
              <SelectItem value="Completed">Completed</SelectItem>
              <SelectItem value="Pending">Pending</SelectItem>
            </SelectGroup>
          </SelectContent>
        </Select>
      </Card>
    </SidebarHeader>
    <SidebarContent> </SidebarContent>
  </Sidebar>
</template>

<style scoped></style>
