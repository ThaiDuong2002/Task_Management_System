import type { AssignmentList } from "@/utils/types";

type AssignmentsState = {
  list: AssignmentList | [];
  isLoading: boolean;
};

export type { AssignmentsState };
