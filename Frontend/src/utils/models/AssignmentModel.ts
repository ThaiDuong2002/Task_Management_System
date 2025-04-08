import { BaseModel } from "./BaseModel";

class Assignment extends BaseModel {
  public userId!: string;
  public title!: string;
  public description!: string;
  public status!: "Pending" | "In Progress" | "Completed";
  public priority!: "Low" | "Medium" | "High";
  public dueDate!: Date;
}

export default Assignment;
