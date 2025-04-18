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
  },
});

export default useAssignmentsStore;
