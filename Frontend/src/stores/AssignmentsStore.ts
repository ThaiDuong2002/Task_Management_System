import type { AssignmentsState } from "@/utils/types";
import { defineStore } from "pinia";

const useAssignmentsStore = defineStore("assignment", {
  state: () =>
    ({
      list: [],
      isLoading: false,
    } as AssignmentsState),
  actions: {},
});

export default useAssignmentsStore;
