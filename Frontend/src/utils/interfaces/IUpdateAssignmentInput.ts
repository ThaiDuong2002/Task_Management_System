interface IUpdateAssignmentInput {
  title?: string;
  description?: string;
  status?: "In progress" | "Completed" | "Pending";
  priority?: "Low" | "Medium" | "High";
  dueDate?: string;
}

export type { IUpdateAssignmentInput };
