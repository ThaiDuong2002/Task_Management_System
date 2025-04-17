interface IAssignmentResponse {
  id: string;
  userId: string;
  title: string;
  description?: string;
  status: "In progress" | "Completed" | "Pending";
  priority: "Low" | "Medium" | "High";
  dueDate: string;
  createdAt: string;
  updatedAt: string;
}

export type { IAssignmentResponse };
