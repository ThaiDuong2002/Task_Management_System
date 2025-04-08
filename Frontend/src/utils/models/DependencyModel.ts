import { BaseModel } from "./BaseModel";

class Dependency extends BaseModel {
  public assignmentId!: string;
  public dependOnAssignmentId!: string;
}

export default Dependency;
