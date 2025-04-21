import type { Notification } from "@/utils/types/Notification";

type NotificationsState = {
  list: Notification[];
  isLoading: boolean;
};

export type { NotificationsState };
