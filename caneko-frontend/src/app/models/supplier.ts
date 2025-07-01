import { IPageParameters } from "./base";

export interface ISupplierFilterInput extends IPageParameters {
    search: string
}

export interface ISupplierFilterViewModel {
    id: string,
    deleted: boolean,
    createdDate?: string,
    updateDate?: string,
    name: string
}

export interface ISupplierFilterPagination extends IPageParameters {
    items: ISupplierFilterViewModel[];
    totalPages: number;
    total: number;
}