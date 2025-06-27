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
    createDate?: string; // tooltip data produto
    updateDate?: string; // tooltip data produto
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

export interface IProductImages extends BaseEntity {
    imagePrincipalUrl: string;
    imageSecondaryUrl: string[];
}

export interface IDetail {
    brand: string; // Marca
    useRecommendId?: string; // Uso recomendado (ex.: casa)
    technicalDescription?: string; // Descrição técnica
    manufacturerId?: string; // Fabricante
    assessment?: number; // Média de avaliações (ex.: 4.5 estrelas)
    height?: number;
    width?: number;
    weight?: number;
    typeColorId?: string; // Tipos de cores para venda
    bussinesUnitId?: string; // Tamanhos diversos
    typeUnitId?: string; // Tamanhos diversos
    size?: number; // Tamanhos diversos
    isHighlight: boolean; // Indica se é destaque
    supplierSaleId?: string; // Vendedor (ex.: própria marca Caneko)
}  

export interface ILot {
    id: string;
    name: string;
    quantity: number;
    arrivalDate: Date;
}

 