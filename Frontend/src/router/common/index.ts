import type { RouteRecordRaw } from "vue-router";
const LoginPage = () => import("@/pages/LoginPage.vue");
const RegisterPage = () => import("@/pages/RegisterPage.vue");

const commonRoutes: RouteRecordRaw[] = [
  {
    path: "/login",
    name: "login",
    component: LoginPage,
    meta: {
      title: "Login",
      layout: "default",
      requiresAuth: false,
    },
  },
  {
    path: "/register",
    name: "register",
    component: RegisterPage,
    meta: {
      title: "Register",
      layout: "default",
      requiresAuth: false,
    },
  },
];

export default commonRoutes;
