import { BaseModel } from "@/utils/models/BaseModel";

class Dependency extends BaseModel {
  public assignmentId!: string;
  public dependOnAssignmentId!: string;
}

export default Dependency;
