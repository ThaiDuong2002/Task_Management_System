class AssignmentService {
  private static instance: AssignmentService;
  private constructor() {}

  public static getInstance(): AssignmentService {
    if (!AssignmentService.instance) {
      AssignmentService.instance = new AssignmentService();
    }
    return AssignmentService.instance;
  }

  public async getAssignments() {}

  public async getAssignment() {}

  public async createAssignment() {}

  public async updateAssignment() {}

  public async deleteAssignment() {}
}

export default AssignmentService;
