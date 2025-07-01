import { IPageParameters } from "./base";

export interface IFilterInput extends IPageParameters {
    search: string
}

export interface IFilterViewModel {
    id: string,
    deleted: boolean,
    createdDate?: string,
    updateDate?: string,
    name: string
}

export interface IFilterPagination extends IPageParameters {
    items: IFilterViewModel[];
    totalPages: number;
    total: number;
}