import { BaseModel } from "@/utils/models/BaseModel";

class User extends BaseModel {
  public username!: string;
  public email!: string;
  public firstname!: string;
  public lastname!: string;
}

export default User;
