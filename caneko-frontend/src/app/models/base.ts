import { HttpContext, HttpHeaders, HttpParams } from "@angular/common/http";

export interface IOptionsAPI {
    headers?: HttpHeaders | Record<string, string | string[]>;
    context?: HttpContext;
    observe?: 'body';
    params?: HttpParams | Record<string, string | number | boolean | ReadonlyArray<string | number | boolean>>;
    reportProgress?: boolean;
    responseType?: 'json';
    withCredentials?: boolean;
}

export interface IPageParameters {
    pageNumber?: number;
    pageSize?: number;
} 

export interface BaseEntity {
    id?: string;
    deleted: boolean;
    createDate?: Date;
    updateDate?: Date;
}