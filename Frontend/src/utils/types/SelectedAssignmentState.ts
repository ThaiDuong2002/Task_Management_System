import type { Assignment } from "@/utils/types";

type SelectedAssignmentState = {
  assignment: Assignment | null;
  isLoading: boolean;
};

export type { SelectedAssignmentState };
