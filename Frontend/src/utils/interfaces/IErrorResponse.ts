interface IErrorResponse {
  type: string;
  title: string;
  status: number;
  traceId: string;
  errors?: Record<string, string[]>;
  errorsCode?: string[];
}

export type { IErrorResponse };
