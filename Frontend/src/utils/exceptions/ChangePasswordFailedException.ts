class ChangePasswordFailedException extends Error {
  constructor(message: string) {
    super(message);
    this.name = "ChangePasswordFailedException";
  }
}

export default ChangePasswordFailedException;
