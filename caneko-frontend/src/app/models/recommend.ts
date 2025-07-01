import { IPageParameters } from "./base";

export interface IRecommendFilterInput extends IPageParameters {
    search: string
}

export interface IRecommendFilterViewModel {
    id: string,
    deleted: boolean,
    createdDate?: string,
    updateDate?: string,
    name: string
}

export interface IRecommendFilterPagination extends IPageParameters {
    items: IRecommendFilterViewModel[];
    totalPages: number;
    total: number;
}