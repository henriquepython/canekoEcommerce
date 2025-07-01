import { IPageParameters } from "./base";
import { IFilterInput, IFilterPagination, IFilterViewModel } from "./generic";

export interface IRecommendFilterInput extends IFilterInput { }

export interface IRecommendFilterViewModel extends IFilterViewModel { }

export interface IRecommendFilterPagination extends IFilterPagination { }