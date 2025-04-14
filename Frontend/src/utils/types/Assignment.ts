type Assignment = {
  id: string;
  title: string;
  description: string;
  dueDate: Date;
  status: "Pending" | "Completed" | "In Progress";
  priority: "Low" | "Medium" | "High";
  createdAt: Date;
  updatedAt: Date;
};

export type { Assignment };
