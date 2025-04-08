import { commonInstance } from "@/services/api/AxiosService";
import type { LoginData } from "@/utils/interfaces";
import { defineStore } from "pinia";

const useAuthStore = defineStore("auth", {
  state: () => ({
    user: {},
    accessToken: null,
    refreshToken: null,
    isAuthenticated: false,
    isLoading: false,
  }),
  actions: {
    async login(login: LoginData) {
      this.isLoading = true;
      try {
        const response = await commonInstance.post("/auth/login", login);

        this.user = {
          id: response.data.id,
          username: response.data.userName,
          email: response.data.email,
          firstName: response.data.firstName,
          lastName: response.data.lastName,
        };

        this.accessToken = response.data.accessToken;
        this.refreshToken = response.data.refreshToken;
      } catch (error) {}
    },
  },
});

export default useAuthStore;
