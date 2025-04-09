import { jwtDecode, type JwtPayload } from "jwt-decode";

const isTokenExpired = (token: string): boolean => {
  const decodedToken = jwtDecode<JwtPayload>(token);

  const currentTime = Math.floor(Date.now() / 1000);
  const expirationTime = decodedToken.exp || 0;

  return currentTime >= expirationTime;
};

export default isTokenExpired;
