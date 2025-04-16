import { authInstance } from "@/services/api/AxiosService";
import { useAuthStore } from "@/stores";
import {
  UserNameAlreadyExistsException,
  UserNotFoundException,
  UserUpdateFailedException,
} from "@/utils/exceptions";
import ChangePasswordFailedException from "@/utils/exceptions/ChangePasswordFailedException";
import InvalidPasswordException from "@/utils/exceptions/InvalidPasswordException";
import type {
  IChangePasswordInput,
  IChangePasswordResponse,
  IUpdateUserInput,
  IUpdateUserResponse,
} from "@/utils/interfaces";

class UserService {
  private static instance: UserService;
  private constructor() {}

  public static getInstance(): UserService {
    if (!UserService.instance) {
      UserService.instance = new UserService();
    }
    return UserService.instance;
  }

  async updateUserName(input: IUpdateUserInput): Promise<IUpdateUserResponse> {
    const auth = useAuthStore();
    try {
      const response = await authInstance.put(`/users/${auth.user?.id}`, input);

      return response.data as IUpdateUserResponse;
    } catch (error: any) {
      const errorCode = error.response.data.errorCodes[0];
      const errorTitle = error.response.data.title;
      switch (errorCode) {
        case "User.NotFound":
          throw new UserNotFoundException(errorTitle);
        case "User.UpdateFailed":
          throw new UserUpdateFailedException(errorTitle);
        case "User.UserNameAlreadyExists":
          throw new UserNameAlreadyExistsException(errorTitle);
        default:
          throw new Error("An error occurred while updating the user name.");
      }
    }
  }

  async changePassword(
    input: IChangePasswordInput
  ): Promise<IChangePasswordResponse> {
    try {
      const auth = useAuthStore();
      const response = await authInstance.put(
        `/users/${auth.user?.id}/password`,
        input
      );

      return response.data as IChangePasswordResponse;
    } catch (error: any) {
      if (error.response.data.errors["User.InvalidPassword"].length > 0) {
        throw new InvalidPasswordException(
          error.response.data.errors["User.InvalidPassword"][0]
        );
      }
      const errorCode = error.response.data.errorCodes[0];
      const errorTitle = error.response.data.title;
      switch (errorCode) {
        case "User.NotFound":
          throw new UserNotFoundException(errorTitle);
        case "User.ChangePasswordFailed":
          throw new ChangePasswordFailedException(errorTitle);
        default:
          throw new Error("An error occurred while changing the password.");
      }
    }
  }
}

export default UserService.getInstance();
