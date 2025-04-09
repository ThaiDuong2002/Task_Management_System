import type { IToken } from "@/utils/interfaces";

const refreshConstant = "refresh_token";
const accessConstant = "access_token";

export const GetRefreshToken = () =>
  localStorage.getItem(refreshConstant) || null;

export const GetAccessToken = () =>
  localStorage.getItem(accessConstant) || null;

export const StoreToken = (token: IToken) => {
  const { accessToken, refreshToken } = token;
  localStorage.setItem(accessConstant, accessToken);
  localStorage.setItem(refreshConstant, refreshToken);
};

export const RemoveToken = () => {
  localStorage.removeItem(accessConstant);
  localStorage.removeItem(refreshConstant);
};
