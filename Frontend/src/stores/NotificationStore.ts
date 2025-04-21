import type { Notification, NotificationsState } from "@/utils/types";
import { defineStore } from "pinia";

const useNotificationStore = defineStore("notification", {
  state: () =>
    ({
      list: [],
      isLoading: false,
    } as NotificationsState),
  actions: {
    addNotification(notification: Notification) {
      this.list.unshift(notification);
    },
    setNotifications(notifications: Notification[]) {
      this.list = notifications;
    },
    setRead(id: string) {
      this.list = this.list.map((notification) => {
        if (notification.id === id) notification.isRead = true;
        return notification;
      });
    },
    setReadAll() {
      this.list = this.list.map((notification) => {
        notification.isRead = true;
        return notification;
      });
    },
  },
});

export default useNotificationStore;
