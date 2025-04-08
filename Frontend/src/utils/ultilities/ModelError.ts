export class ModelError {
  public readonly type!: string;
  public readonly title!: string;
  public readonly status!: number;
  public readonly traceId!: string;
  public readonly errors?: Record<string, string[]>;
  public readonly errorCodes?: string[];

  constructor(data: {
    type: string;
    title: string;
    status: number;
    traceId: string;
    errors?: Record<string, string[]>;
    errorCodes?: string[];
  }) {
    this.type = data.type;
    this.title = data.title;
    this.status = data.status;
    this.traceId = data.traceId;
    this.errors = data.errors;
    this.errorCodes = data.errorCodes;
  }
}
