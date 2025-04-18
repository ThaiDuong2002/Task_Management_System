import type { Assignment, SelectedAssignmentState } from "@/utils/types";
import { defineStore } from "pinia";

const useSelectedAssignmentStore = defineStore("selectedAssignment", {
  state: () =>
    ({
      assignment: {
        id: "",
        title: "",
        description: "",
        dueDate: new Date("2023-10-01"),
        status: "Pending",
        priority: "Low",
        createdAt: new Date("2023-10-01"),
        updatedAt: new Date("2023-10-01"),
      },
      isLoading: false,
      isSidebarOpen: false,
    } as SelectedAssignmentState),
  actions: {
    toggleSidebar(id: string) {
      if (id === this.assignment.id) this.isSidebarOpen = !this.isSidebarOpen;
      else this.isSidebarOpen = true;
    },
    closeSidebar() {
      this.isSidebarOpen = false;
    },
    setAssignment(assignment: Assignment) {
      this.assignment = assignment;
    },
  },
});

export default useSelectedAssignmentStore;
