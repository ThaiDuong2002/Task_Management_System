import { autoAnimatePlugin } from "@formkit/auto-animate/vue";
import { createPinia } from "pinia";
import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";
import { useAuthStore } from "./stores";
import "./style.css";

const app = createApp(App);
const pinia = createPinia();

app.use(pinia);

const auth = useAuthStore();
await auth.checkAuthStatus();

app.use(router);
app.use(autoAnimatePlugin);
app.mount("#app");
