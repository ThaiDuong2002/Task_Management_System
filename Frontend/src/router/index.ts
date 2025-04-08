import commonRoutes from "@/router/common";
import guardRoutes from "@/router/guard";
import { createRouter, createWebHistory } from "vue-router";

const router = createRouter({
  history: createWebHistory(),
  routes: [...commonRoutes, ...guardRoutes],
});

router.beforeEach((to, from, next) => {
  document.title = (to.meta.title as string) || "Tasks Manager";
  if (to.meta.requiresAuth) {
    next({ name: "login" });
  } else {
    next();
  }
});

export default router;
