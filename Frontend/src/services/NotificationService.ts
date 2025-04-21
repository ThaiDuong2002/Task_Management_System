import type {
  INotificationInput,
  INotificationResponse,
} from "@/utils/interfaces";
import { authInstance } from "./api/AxiosService";

class NotificationService {
  private static instance: NotificationService;

  private constructor() {}

  public static getInstance(): NotificationService {
    if (!NotificationService.instance) {
      NotificationService.instance = new NotificationService();
    }

    return NotificationService.instance;
  }

  async getNotifications(
    input: INotificationInput
  ): Promise<INotificationResponse[]> {
    try {
      const response = await authInstance.get(
        `/notifications/${input.userId}`,
        {
          params: {
            page: input.page,
            limit: input.limit,
          },
        }
      );

      return response.data as INotificationResponse[];
    } catch (error: any) {
      throw new Error("An error occurred while getting the notifications.");
    }
  }
}

export default NotificationService.getInstance();
