import type { Assignment } from "@/utils/types";

type SelectedAssignmentState = {
  assignment: Assignment;
  isLoading: boolean;
  isSidebarOpen: boolean;
};

export type { SelectedAssignmentState };
