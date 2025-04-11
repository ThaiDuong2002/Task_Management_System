class DuplicateEmailException extends Error {
  constructor(email: string) {
    super(`Email ${email} already exists`);
    this.name = "DuplicateEmailException";
  }
}

export default DuplicateEmailException;
