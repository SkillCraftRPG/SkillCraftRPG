import { stringUtils } from "logitar-js";

import type { ApiFailure, ApiResult, ApiVersion } from "~/types/api";

const contentType: string = "Content-Type";
const { combineURL, isAbsoluteURL } = stringUtils;

async function execute<TData, TResult>(method: string, url: string, data?: TData): Promise<ApiResult<TResult>> {
  let body: string | undefined = undefined;
  const headers: HeadersInit = new Headers();
  if (data) {
    body = JSON.stringify(data);
    headers.set(contentType, "application/json; charset=UTF-8");
  }

  const config = useRuntimeConfig();
  const apiBaseUrl: string = config.public.apiBaseUrl;
  const input: string = isAbsoluteURL(url) ? url : combineURL(apiBaseUrl, url);

  const response: Response = await fetch(input, { method, headers, body, credentials: "include" });

  let result: unknown = undefined;
  const resultType: string | null = response.headers.get(contentType);
  if (resultType) {
    if (resultType.includes("json")) {
      result = await response.json();
    } else if (resultType.includes("text")) {
      result = await response.text();
    } else {
      throw new Error(`The content type "${resultType}" is not supported.`);
    }
  }

  if (!response.ok) {
    const error: ApiFailure = { data: result, status: response.status };
    throw error;
  }

  return { data: result as TResult, status: response.status };
}

export async function _delete<TResult>(url: string): Promise<ApiResult<TResult>> {
  return await execute("DELETE", url);
}

export async function get<TResult>(url: string): Promise<ApiResult<TResult>> {
  return await execute("GET", url);
}

export async function getVersion(): Promise<ApiVersion> {
  return (await get<ApiVersion>("/")).data;
}

export async function patch<TData, TResult>(url: string, data?: TData): Promise<ApiResult<TResult>> {
  return await execute("PATCH", url, data);
}

export async function post<TData, TResult>(url: string, data?: TData): Promise<ApiResult<TResult>> {
  return await execute("POST", url, data);
}

export async function put<TData, TResult>(url: string, data?: TData): Promise<ApiResult<TResult>> {
  return await execute("PUT", url, data);
}
