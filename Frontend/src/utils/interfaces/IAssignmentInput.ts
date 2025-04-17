interface IAssignmentInput {
  userId: string;
  title: string;
  description?: string;
  status?: "In progress" | "Completed" | "Pending";
  priority?: "Low" | "Medium" | "High";
  dueDate: string;
}

export type { IAssignmentInput };
