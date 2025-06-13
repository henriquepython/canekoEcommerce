import { Injectable, inject } from '@angular/core';
import { IProductFilterInput, IProductFilterPagination, IProductFilterViewModel } from '../models/product';
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

  createProduct(data: any): Observable<any> {
    return this._http.post(this.apiProduct, data);
  }

  updateProduct(id: string, data: any): Observable<any> {
    return this._http.put(`${this.apiProduct}/${id}`, data);
  }

  filter(filters: IProductFilterInput): Observable<IProductFilterPagination> {
    console.log("env", environment.apiUrl)
    const params = new HttpParams()
      .set('search', filters.search ?? '' )
      .set('isStock',  filters.isStock ?? false )
      .set('pageNumber', filters.pageNumber ?? 1)
      .set('pageSize', filters.pageSize ?? 12);

    return this._http.get<IProductFilterPagination>(`${this.apiProduct}/filter`, {params});
  }

  deleteProduct(id: string): Observable<any> {
    return this._http.delete(`${this.apiProduct}/${id}`);
  }

  disableProduct(idInput: string, isDisableItem: boolean): Observable<any> {
    return this._http.post(`${this.apiProduct}/disable`, { id: idInput, isDisable: isDisableItem });
  }
}
