import { createRouter, createWebHistory } from "vue-router";
import commonRoutes from "./common";
import guardRoutes from "./guard";

const router = createRouter({
  history: createWebHistory(),
  routes: [...commonRoutes, ...guardRoutes],
});

router.beforeEach((to, from, next) => {
  document.title = to.meta.title as string || "Tasks Manager";
  next();
});

export default router;
