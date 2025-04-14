import type { SelectedAssignmentState } from "@/utils/types";
import { defineStore } from "pinia";

const useSelectedAssignmentStore = defineStore("selectedAssignment", {
  state: () =>
    ({
      assignment: null,
      isLoading: false,
    } as SelectedAssignmentState),
  actions: {},
});

export default useSelectedAssignmentStore;
