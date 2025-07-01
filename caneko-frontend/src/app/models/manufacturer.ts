import { IPageParameters } from "./base";

export interface IManufacturerFilterInput extends IPageParameters {
    search: string
}

export interface IManufacturerFilterViewModel {
    id: string,
    deleted: boolean,
    createdDate?: string,
    updateDate?: string,
    name: string
}

export interface IManufacturerFilterPagination extends IPageParameters {
    items: IManufacturerFilterViewModel[];
    totalPages: number;
    total: number;
}