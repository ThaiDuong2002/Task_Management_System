export class ModelError {
  public readonly type!: string;
  public readonly title!: string;
  public readonly status!: number;
  public readonly traceId!: string;
  public readonly errors?: Record<string, string[]>;
  public readonly errorCodes?: string[];
}
