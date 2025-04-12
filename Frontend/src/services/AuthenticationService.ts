import { commonInstance } from "@/services/api/AxiosService";
import {
  DuplicateEmailException,
  InvalidCredentialsException,
  RegisterFailedException,
} from "@/utils/exceptions";
import type {
  ILoginInput,
  ILoginResponse,
  IRegisterInput,
  IToken,
  IUser,
} from "@/utils/interfaces";

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

      return response.data as ILoginResponse;
    } catch (error: any) {
      throw new InvalidCredentialsException(
        error.response.data.errors["Auth.InvalidCred"][0]
      );
    }
  }

  async register(input: IRegisterInput): Promise<IUser> {
    try {
      const response = await commonInstance.post("/auth/register", input);

      return response.data as IUser;
    } catch (error: any) {
      if (error.response.data.errors["User.FailedToRegister"].length > 0) {
        throw new RegisterFailedException(
          error.response.data.errors["User.FailedToRegister"][0]
        );
      } else if (error.response.data.errorCodes.length > 0) {
        console.log(error.response.data.errorCodes[0]);
        throw new DuplicateEmailException(error.response.data.errorCodes[0]);
      } else {
        throw new Error("Registration failed!");
      }
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

  async getMe(token: IToken): Promise<ILoginResponse> {
    try {
      const response = await commonInstance.post("/auth/get-me", token);

      if (response.status !== 200) {
        throw new Error("Get user failed: " + response.statusText);
      }

      return response.data as ILoginResponse;
    } catch (error) {
      throw new Error("Get user failed: " + (error as Error).message);
    }
  }
}

export default AuthenticationService.getInstance();
