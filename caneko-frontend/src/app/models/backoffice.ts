export interface ISideBarBackoffice {
    name: string;
    path: string;
    route: string;
}

export enum BackofficeRoute {
    HOME = 'init',
    DASHBOARD = 'dashboard',
    PRODUCT = 'products',
    STOCK = 'stock',
    ORDER = 'order',
    REPORT = 'report',
    MARKETING = 'marketing',
    CONFIG = 'config'
}