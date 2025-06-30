import { BaseEntity, IPageParameters } from "./base";

export interface IProductFilterInput extends IPageParameters {
    search?: string;
    isStock?: boolean;
}

export interface IProductFilterPagination {
  products: IProductFilterViewModel[];
  pageNumber: number;
  pageSize: number;
  totalPages: number;
  total: number;
}

export interface IProductFilterViewModel {
    id: string;
    sequencialId: string;
    deleted: boolean;
    createDate?: string;
    updateDate?: string;
    name: string;
    description?: string;
  
    // stock => usar tooltip estoque
    stock?: IStock; 
    category?: ICategory;
    images?: IProductImages;
    details?: IDetail;
}

export interface IStock extends BaseEntity {
    productId: string;
    lot?: ILot[];
    factoryPrice: number;
    profitMarginPercent: number;
    quantityTotal: number;
    salePrice: number
}

export interface ICategory extends BaseEntity {
    name?: string;
}

export interface IBrand extends BaseEntity {
    name?: string;
}

export interface IColorItem extends BaseEntity {
    name?: string;
}

export interface IManufacturer extends BaseEntity {
    name?: string;
}

export interface ISupplier extends BaseEntity {
    name?: string;
}

export interface IUseRecommend extends BaseEntity {
    name?: string;
}

export interface IUnitMeasurement extends BaseEntity {
    name?: string;
    acronym?: string;
}

export interface IProductImages extends BaseEntity {
    imagePrincipalUrl: string;
    imageSecondaryUrl: string[];
}

export interface IDetail {
    brand: string;
    useRecommendId?: string;
    technicalDescription?: string;
    manufacturerId?: string;
    assessment?: number; // Média de avaliações (ex.: 4.5 estrelas)
    height?: number;
    width?: number;
    weight?: number;
    typeColorId?: string;
    bussinesUnitId?: string;
    typeUnitId?: string;
    size?: number;
    isHighlight: boolean;
    supplierSaleId?: string;
}  

export interface ILot {
    id: string;
    name: string;
    quantity: number;
    arrivalDate: Date;
}

 