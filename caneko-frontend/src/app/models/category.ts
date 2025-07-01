import { IPageParameters } from "./base";

export interface ICategoryFilterInput extends IPageParameters {
    search: string
}

export interface ICategoryFilterViewModel {
    id: string,
    deleted: boolean,
    createdDate?: string,
    updateDate?: string,
    name: string
}

export interface ICategoryFilterPagination extends IPageParameters {
    items: ICategoryFilterViewModel[];
    totalPages: number;
    total: number;
}