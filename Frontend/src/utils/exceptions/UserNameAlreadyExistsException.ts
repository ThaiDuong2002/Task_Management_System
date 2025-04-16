class UserNameAlreadyExistsException extends Error {
  constructor(message: string) {
    super(message);
    this.name = "UserNameAlreadyExistsException";
  }
}

export default UserNameAlreadyExistsException;
