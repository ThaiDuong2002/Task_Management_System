interface INotificationResponse {
  id: string;
  userId: string;
  assignmentId: string;
  message: string;
  type: "Upcoming" | "Overdue";
  isRead: boolean;
  scheduledTime: Date;
  createdAt: Date;
  updatedAt: Date;
}

export type { INotificationResponse };
