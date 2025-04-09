import type { IToken } from "./IToken";
import type { IUser } from "./IUser";

interface ILoginResponse {
  user: IUser;
  token: IToken;
}

export type { ILoginResponse };
