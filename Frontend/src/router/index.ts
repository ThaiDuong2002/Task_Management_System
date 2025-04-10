import commonRoutes from "@/router/common";
import guardRoutes from "@/router/guard";
import { useAuthStore } from "@/stores";
import { createRouter, createWebHistory } from "vue-router";
const NotFound = () => import("@/pages/NotFound.vue");

const router = createRouter({
  history: createWebHistory(),
  routes: [
    ...guardRoutes,
    ...commonRoutes,
    {
      path: "/:pathMatch(.*)*",
      name: "not-found",
      component: NotFound,
      meta: {
        title: "Not Found",
        requiresAuth: false,
        layout: "default",
      },
    },
  ],
});

router.beforeEach(async (to, from, next) => {
  document.title = (to.meta.title as string) || "Tasks Manager";
  const auth = useAuthStore();

  if (to.meta.requiresAuth && !auth.isAuthenticated) {
    next({ name: "login" });
  }

  if (!to.meta.requiresAuth && auth.isAuthenticated) {
    if (to.name === "login") {
      next({ name: "assignments" });
    }
    if (to.name === "register") {
      next({ name: "assignments" });
    }
  }
  next();
});

export default router;
