import type { IToken, IUser } from "../interfaces";

export type AuthState = {
  user: IUser | null;
  token: IToken | null;
  isAuthenticated: boolean;
  isLoading: boolean;
};
