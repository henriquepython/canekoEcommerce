import { Injectable, inject } from '@angular/core';
import { IProductFilterInput, IProductFilterViewModel } from '../models/product';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private _http = inject(HttpClient);
  apiProduct = `${environment.apiUrl}/Product`

  constructor() { }

  async createProduct(data: any) {
    const result = this._http.post(this.apiProduct, data);
  }

  updateProduct(id: string, data: any) {
    const result = this._http.put(`${this.apiProduct}/${id}`, data);
  }

  filter(filters: IProductFilterInput): Observable<IProductFilterViewModel[]> {
    console.log("env", environment.apiUrl)
    const params = new HttpParams()
      .set('search', filters.search ?? '' )
      .set('isStock',  filters.isStock ?? false )
      .set('pageNumber', filters.pageNumber ?? 1)
      .set('pageSize', filters.pageSize ?? 12);

    const products = this._http.get<IProductFilterViewModel[]>(`${this.apiProduct}/filter`, {params});

    return products;
  }

  deleteProduct(id: string) {
    this._http.delete(`${this.apiProduct}/${id}`);
  }

  disableProduct(id: string, isDisable: boolean) {
    const params = new HttpParams()
      .set('id', id )
      .set('isDisable', isDisable) ;

    this._http.get<IProductFilterViewModel[]>(`${this.apiProduct}/disable`, {params});
  }
}
