import { AuthenticationService } from "@/services";
import {
  GetAccessToken,
  GetRefreshToken,
  RemoveToken,
  StoreToken,
} from "@/stores";
import type { ILoginInput } from "@/utils/interfaces";
import type { AuthState } from "@/utils/types";
import { defineStore } from "pinia";

const useAuthStore = defineStore("auth", {
  state: () =>
    ({
      user: null,
      token: null,
      isAuthenticated: false,
      isLoading: false,
    } as AuthState),
  actions: {
    async login(login: ILoginInput) {
      try {
        this.isLoading = true;

        const response = await AuthenticationService.login(login);
        this.user = response.user;
        this.token = response.token;

        StoreToken(response.token);

        this.isAuthenticated = true;

        this.isLoading = false;
      } catch (error) {
        this.isLoading = false;
        throw error;
      }
    },
    logout() {
      try {
        this.isLoading = true;

        this.user = null;
        this.token = null;
        this.isAuthenticated = false;

        RemoveToken();

        this.isLoading = false;
      } catch (error) {
        this.isLoading = false;
        throw error;
      }
    },
    async checkAuthStatus() {
      try {
        this.isLoading = true;

        const accessToken = GetAccessToken();
        const refreshToken = GetRefreshToken();

        if (!accessToken || !refreshToken) {
          this.isAuthenticated = false;
          this.user = null;
          this.token = null;
          this.isLoading = false;
          RemoveToken();
          return;
        }

        const response = await AuthenticationService.getMe(accessToken);

        this.user = response;
        this.token = {
          accessToken: accessToken,
          refreshToken: refreshToken,
        };

        this.isAuthenticated = true;

        this.isLoading = false;
      } catch (error) {
        this.isLoading = false;
        throw error;
      }
    },
  },
});

export default useAuthStore;
