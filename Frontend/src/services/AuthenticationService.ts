import type {
  ILoginInput,
  ILoginResponse,
  IRegisterInput,
  IToken,
  IUser,
} from "@/utils/interfaces";
import { commonInstance } from "./api/AxiosService";

class AuthenticationService {
  private static instance: AuthenticationService;

  private constructor() {}

  public static getInstance(): AuthenticationService {
    if (!AuthenticationService.instance) {
      AuthenticationService.instance = new AuthenticationService();
    }
    return AuthenticationService.instance;
  }

  async login(input: ILoginInput): Promise<ILoginResponse> {
    try {
      const response = await commonInstance.post("/auth/login", input);

      if (response.status !== 200) {
        throw new Error("Login failed: " + response.statusText);
      }

      return response.data as ILoginResponse;
    } catch (error) {
      throw new Error("Login failed: " + (error as Error).message);
    }
  }

  async register(input: IRegisterInput): Promise<IUser> {
    try {
      const response = await commonInstance.post("/auth/register", input);

      if (response.status !== 201) {
        throw new Error("Registration failed: " + response.statusText);
      }

      return response.data as IUser;
    } catch (error) {
      throw new Error("Registration failed: " + (error as Error).message);
    }
  }

  async refreshToken(input: IToken): Promise<IToken> {
    try {
      const response = await commonInstance.post("/auth/refresh-token", input);

      if (response.status !== 200) {
        throw new Error("Token refresh failed: " + response.statusText);
      }

      return response.data as IToken;
    } catch (error) {
      throw new Error("Token refresh failed: " + (error as Error).message);
    }
  }

  async getMe(token: string): Promise<IUser> {
    try {
      const response = await commonInstance.post("/auth/get-me", {
        accessToken: token,
      });

      if (response.status !== 200) {
        throw new Error("Get user failed: " + response.statusText);
      }

      return response.data as IUser;
    } catch (error) {
      throw new Error("Get user failed: " + (error as Error).message);
    }
  }
}

export default AuthenticationService.getInstance();
