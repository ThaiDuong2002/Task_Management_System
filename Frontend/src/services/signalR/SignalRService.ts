import { GetAccessToken } from "@/stores";
import * as signalR from "@microsoft/signalr";

const connecttionUrl = import.meta.env.VITE_SIGNALR_URL;

const connection = new signalR.HubConnectionBuilder()
  .withUrl(connecttionUrl, {
    accessTokenFactory: () => GetAccessToken() || "",
  })
  .build();

export default connection;
