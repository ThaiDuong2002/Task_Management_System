class AssignmentNotFoundException extends Error {
  constructor(message: string) {
    super(message);
    this.name = "AssignmentNotFoundException";
  }
}

export default AssignmentNotFoundException;
