import AssignmentNotFoundException from "@/utils/exceptions/AssignmentNotFoundException";
import type {
  IAssignmentInput,
  IAssignmentResponse,
  IAssignmentsInput,
  IUpdateAssignmentInput,
  IUpdateAssignmentResponse,
} from "@/utils/interfaces";
import { authInstance } from "./api/AxiosService";

class AssignmentService {
  private static instance: AssignmentService;
  private constructor() {}

  public static getInstance(): AssignmentService {
    if (!AssignmentService.instance) {
      AssignmentService.instance = new AssignmentService();
    }
    return AssignmentService.instance;
  }

  public async getAssignments(
    input: IAssignmentsInput
  ): Promise<IAssignmentResponse[]> {
    try {
      const params = {
        page: input.page,
        limit: input.limit,
        status: input.status,
        priority: input.priority,
        options: input.options,
      };
      const response = await authInstance.get(
        `/assignments/list/${input.userId}`,
        {
          params: params,
        }
      );

      return response.data as IAssignmentResponse[];
    } catch (error: any) {
      throw new Error("An error occurred while getting the assignments.");
    }
  }

  public async getAssignment(id: string): Promise<IAssignmentResponse> {
    try {
      const response = await authInstance.get(`/assignments/${id}`);

      return response.data as IAssignmentResponse;
    } catch (error: any) {
      if (error.response.data.errorCodes[0] === "Assignment.NotFound") {
        throw new AssignmentNotFoundException(error.response.data.title);
      } else {
        throw new Error("An error occurred while getting the assignment.");
      }
    }
  }

  public async createAssignment(
    input: IAssignmentInput
  ): Promise<IAssignmentResponse> {
    try {
      const response = await authInstance.post("/assignments", input);

      return response.data as IAssignmentResponse;
    } catch (error: any) {
      throw new Error("An error occurred while creating the assignment.");
    }
  }

  public async updateAssignment(
    id: string,
    input: IUpdateAssignmentInput
  ): Promise<IUpdateAssignmentResponse> {
    try {
      const response = await authInstance.put(`/assignments/${id}`, input);

      return response.data as IUpdateAssignmentResponse;
    } catch (error: any) {
      if (error.response.data.errors["DueDate"].length > 0) {
        throw new Error(error.response.data.errors["DueDate"][0]);
      } else {
        throw new Error("An error occurred while updating the assignment.");
      }
    }
  }

  public async deleteAssignment(id: string): Promise<void> {
    try {
      await authInstance.delete(`/assignments/${id}`);
    } catch (error: any) {
      throw new Error("An error occurred while deleting the assignment.");
    }
  }
}

export default AssignmentService.getInstance();
