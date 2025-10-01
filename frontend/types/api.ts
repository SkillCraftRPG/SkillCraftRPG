export type ApiError = {
  code: string;
  message: string;
  data: Record<string, unknown>;
};

export type ApiFailure = {
  data?: unknown;
  status: number;
};

export type ApiResult<T> = {
  data: T;
  status: number;
};

export type ApiVersion = {
  title: string;
  version: string;
};

export enum ErrorCodes {
  InvalidCredentials = "InvalidCredentials",
  LicenseAlreadyUsed = "LicenseAlreadyUsed",
  NumberAlreadyUsed = "NumberAlreadyUsed",
  UniqueNameAlreadyUsed = "UniqueNameAlreadyUsed",
}

export type ProblemDetails = {
  type?: string | null;
  title?: string | null;
  status?: number | null;
  detail?: string | null;
  instance?: string | null;
  error?: ApiError | null;
};

export enum StatusCodes {
  BadRequest = 400,
  NotFound = 404,
  Conflict = 409,
}
