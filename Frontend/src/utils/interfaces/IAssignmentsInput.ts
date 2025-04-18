interface IAssignmentsInput {
  userId: string;
  page?: number;
  limit?: number;
  status?: "In progress" | "Completed" | "Pending";
  priority?: "Low" | "Medium" | "High";
  options?: "upcoming" | "overdue" | "today";
}

export type { IAssignmentsInput };
