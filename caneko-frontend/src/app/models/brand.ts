import { IPageParameters } from "./base";

export interface IBrandFilterInput extends IPageParameters {
    search: string
}

export interface IBrandFilterViewModel {
    id: string,
    deleted: boolean,
    createdDate?: string,
    updateDate?: string,
    name: string
}

export interface IBrandFilterPagination extends IPageParameters {
    items: IBrandFilterViewModel[];
    totalPages: number;
    total: number;
}