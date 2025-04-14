import type { SelectedAssignmentState } from "@/utils/types";
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
    toggleSidebar() {
      if (this.isSidebarOpen) {
        this.assignment = null;
        this.isSidebarOpen = false;
      } else {
        this.isSidebarOpen = true;
      }
    },
  },
});

export default useSelectedAssignmentStore;
