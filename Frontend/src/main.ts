import { autoAnimatePlugin } from "@formkit/auto-animate/vue";
import { createPinia } from "pinia";
import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";
import "./style.css";

const app = createApp(App);
const pinia = createPinia();

app.use(router);
app.use(autoAnimatePlugin);
app.use(pinia);
app.mount("#app");
