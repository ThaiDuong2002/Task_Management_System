class UserUpdateFailedException extends Error {
  constructor(message: string) {
    super(message);
    this.name = "UserUpdateFailedException";
  }
}

export default UserUpdateFailedException;
