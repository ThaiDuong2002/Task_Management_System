class RegisterFailedException extends Error {
  constructor(message: string) {
    super(message);
    this.name = "RegisterFailedException";
  }
}

export default RegisterFailedException;
