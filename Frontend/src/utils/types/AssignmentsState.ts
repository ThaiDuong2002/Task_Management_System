import type { Assignment } from "@/utils/types";

type AssignmentsState = {
  list: Assignment[] | [];
  isLoading: boolean;
};

export type { AssignmentsState };
