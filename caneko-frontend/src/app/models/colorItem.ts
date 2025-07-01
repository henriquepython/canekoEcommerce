import { IPageParameters } from "./base";

export interface IColorItemFilterInput extends IPageParameters {
    search: string
}

export interface IColorItemFilterViewModel {
    id: string,
    deleted: boolean,
    createdDate?: string,
    updateDate?: string,
    name: string
}

export interface IColorItemFilterPagination extends IPageParameters {
    items: IColorItemFilterViewModel[];
    totalPages: number;
    total: number;
}