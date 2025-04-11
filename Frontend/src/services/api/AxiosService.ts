import {
  GetAccessToken,
  GetRefreshToken,
  StoreToken,
  useAuthStore,
} from "@/stores";
import { apiDomain } from "@/utils/constants";
import axios, { type AxiosInstance } from "axios";
import AuthenticationService from "../AuthenticationService";

class AxiosService {
  private static authInstance: AxiosInstance;
  private static commonInstance: AxiosInstance;

  public static getAuthInstance(): AxiosInstance {
    if (!AxiosService.authInstance) {
      AxiosService.createAuthInstance();
    }
    return AxiosService.authInstance;
  }

  public static createAuthInstance() {
    AxiosService.authInstance = axios.create({
      baseURL: apiDomain,
      headers: {
        "Content-Type": "application/json",
      },
      timeout: 10000,
    });

    AxiosService.authInstance.interceptors.request.use((request) => {
      request.headers.Authorization = `Bearer ${localStorage.getItem(
        "access_token"
      )}`;
      return request;
    });

    AxiosService.authInstance.interceptors.response.use(
      (response) => response,
      async (error) => {
        if (error) {
          const originalRequest = error?.config;
          if (error?.response?.status === 401) {
            originalRequest.sent = true;
            const refreshToken = GetRefreshToken();
            const accessToken = GetAccessToken();
            if (refreshToken && accessToken) {
              try {
                const response = await AuthenticationService.refreshToken({
                  accessToken,
                  refreshToken,
                });

                StoreToken({
                  accessToken: response.accessToken,
                  refreshToken: response.refreshToken,
                });

                const newConfig = { ...originalRequest };
                newConfig.headers.Authorization = `Bearer ${response.accessToken}`;

                return axios(newConfig);
              } catch (err) {
                useAuthStore().logout();
                window.location.href = "/login";
                console.error("Error refreshing token:", err);
              }
            } else {
              useAuthStore().logout();
              window.location.href = "/login";
            }
          }
        }
      }
    );
  }

  public static getCommonInstance(): AxiosInstance {
    if (!AxiosService.commonInstance) {
      AxiosService.createCommonInstance();
    }
    return AxiosService.commonInstance;
  }

  public static createCommonInstance() {
    AxiosService.commonInstance = axios.create({
      baseURL: apiDomain,
      headers: {
        "Content-Type": "application/json",
      },
      timeout: 10000,
    });
  }
}

const authInstance = AxiosService.getAuthInstance();
const commonInstance = AxiosService.getCommonInstance();

export { authInstance, commonInstance };
export default AxiosService;
