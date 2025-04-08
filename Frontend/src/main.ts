import { autoAnimatePlugin } from "@formkit/auto-animate/vue";
import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";
import "./style.css";

const app = createApp(App);

app.use(router);
app.use(autoAnimatePlugin);
app.mount("#app");
