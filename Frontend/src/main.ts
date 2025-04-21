import App from "@/App.vue";
import router from "@/router";
import { NotificationService, SignalRService } from "@/services";
import { useAuthStore } from "@/stores";
import "@/style.css";
import { autoAnimatePlugin } from "@formkit/auto-animate/vue";
import { createPinia } from "pinia";
import { createApp } from "vue";
import useNotificationStore from "./stores/NotificationStore";

const app = createApp(App);
const pinia = createPinia();

app.use(pinia);

const auth = useAuthStore();
await auth.checkAuthStatus();

SignalRService.on("ReceiveNotification", async (message) => {
  const notifications = useNotificationStore();
  console.log(message);

  const notificationResult = await NotificationService.getNotifications({
    userId: auth.user?.id!,
  });

  notifications.setNotifications(notificationResult);
});

app.use(router);
app.use(autoAnimatePlugin);
app.mount("#app");
