import type { IAssignmentResponse } from "@/utils/interfaces";
import type { Assignment } from "@/utils/types";

const transformResponseToAssignment = (
  response: IAssignmentResponse
): Assignment => {
  return {
    id: response.id,
    title: response.title,
    description: response.description || "",
    dueDate: new Date(response.dueDate),
    status: response.status,
    priority: response.priority,
    createdAt: new Date(response.createdAt),
    updatedAt: new Date(response.updatedAt),
  };
};

const transformResponseToAssignments = (
  response: IAssignmentResponse[]
): Assignment[] => {
  return response.map(transformResponseToAssignment);
};

export { transformResponseToAssignment, transformResponseToAssignments };
