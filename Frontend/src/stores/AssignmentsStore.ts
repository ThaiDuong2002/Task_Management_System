import type { Assignment, AssignmentsState } from "@/utils/types";
import { defineStore } from "pinia";

const useAssignmentsStore = defineStore("assignment", {
  state: () =>
    ({
      list: [],
      isLoading: false,
    } as AssignmentsState),
  actions: {
    setAssignments(assignments: Assignment[]) {
      this.list = assignments;
    },
    deleteAssignment(id: string) {
      this.list = this.list.filter((assignment) => assignment.id !== id);
    },
    addAssignment(assignment: Assignment) {
      this.list.unshift(assignment);
    },
    updateAssignment(assignment: Assignment) {
      this.list = this.list.map((a) =>
        a.id === assignment.id ? assignment : a
      );
    },
  },
});

export default useAssignmentsStore;
