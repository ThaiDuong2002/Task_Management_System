import type { IToken } from "@/utils/interfaces/IToken";
import type { IUser } from "@/utils/interfaces/IUser";

interface ILoginResponse {
  user: IUser;
  token: IToken;
}

export type { ILoginResponse };
