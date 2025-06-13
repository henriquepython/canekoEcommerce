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
    useRecommend?: string; // Uso recomendado (ex.: casa)
    technicalDescription?: string; // Descrição técnica
    manufacturer?: string; // Fabricante
    assessment?: number; // Média de avaliações (ex.: 4.5 estrelas)
    height?: string;
    width?: string;
    weight?: string;
    typeColor?: string[]; // Tipos de cores para venda
    typeUnits?: string[]; // Tamanhos diversos
    isHighlight: boolean; // Indica se é destaque
    supplierSale?: string; // Vendedor (ex.: própria marca Caneko)
}  

export interface ILot {
    id: string;
    name: string;
    quantity: number;
    arrivalDate: Date;
}

export const mockStock: IStock = {
    id: 'stock001',
    productId: 'prod123',
    deleted: false,
    createDate: new Date('2024-01-10T08:30:00'),
    updateDate: new Date('2024-02-15T14:45:00'),
    factoryPrice: 19.99,
    profitMarginPercent: 30,
    quantityTotal: 150,
    salePrice: 25.99,
    lot: [
      {
        id: 'lotA01',
        name: 'Lote A01',
        quantity: 75,
        arrivalDate: new Date('2024-02-01T10:00:00'),
      },
      {
        id: 'lotB02',
        name: 'Lote B02',
        quantity: 75,
        arrivalDate: new Date('2024-02-10T15:00:00'),
      }
    ]
  };
  
export const mockCategory: ICategory = {
    id: 'cat001',
    deleted: false,
    createDate: new Date('2024-01-10T08:30:00'),
    updateDate: new Date('2024-02-15T14:45:00'),
    name: 'Utilidades Domésticas',
};

export const mockProductImages: IProductImages = {
    id: 'img001',
    deleted: false,
    imagePrincipalUrl: 'https://example.com/caneca-principal.jpg',
    imageSecondaryUrl: [
      'https://example.com/caneca1.jpg',
      'https://example.com/caneca2.jpg',
      'https://example.com/caneca3.jpg'
    ]
};

export const mockProductFilter: IProductFilterViewModel = {
    id: '12345',
    sequencialId: '1001',
    deleted: false,
    createDate: '2024-01-10',
    updateDate: '2024-02-15',
    name: 'Caneca Personalizada',
    stock: mockStock,
    category: mockCategory,
    images: mockProductImages,
    details: {
      brand: 'Caneko',
      useRecommend: 'Casa, Escritório',
      technicalDescription: 'Caneca de cerâmica personalizada, 350ml, resistente a altas temperaturas.',
      manufacturer: 'Caneko Ltda.',
      assessment: 4.7,
      height: '10cm',
      width: '8cm',
      weight: '320g',
      typeColor: ['Branco', 'Preto', 'Vermelho'],
      typeUnits: ['350ml', '500ml', '750ml'],
      isHighlight: true,
      supplierSale: 'Caneko Oficial'
    }
  };

 