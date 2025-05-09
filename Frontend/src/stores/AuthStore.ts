import { AuthenticationService } from "@/services";
import {
  GetAccessToken,
  GetRefreshToken,
  RemoveToken,
  StoreToken,
} from "@/stores";
import { isTokenExpired } from "@/utils/functions";
import type { ILoginResponse } from "@/utils/interfaces";
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
    async setAuth(input: ILoginResponse) {
      try {
        this.isLoading = true;

        this.user = input.user;
        this.token = input.token;

        StoreToken(input.token);

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

        if (!accessToken || !refreshToken || isTokenExpired(refreshToken)) {
          this.logout();
          return;
        }

        const response = await AuthenticationService.getMe({
          accessToken,
          refreshToken,
        });

        this.user = response.user;
        this.token = {
          accessToken: response.token.accessToken,
          refreshToken: response.token.refreshToken,
        };

        StoreToken(this.token);

        this.isAuthenticated = true;

        this.isLoading = false;
      } catch (error) {
        this.logout();
        throw error;
      }
    },
    setUser(user: any) {
      this.user = {
        ...this.user,
        ...user,
      };
    },
  },
});

export default useAuthStore;
