import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { ISupplierFilterInput, ISupplierFilterPagination } from '../models/supplier';

@Injectable({
  providedIn: 'root'
})
export class SupplierService {

  private _http = inject(HttpClient);
  apiSupplier = `${environment.apiUrl}/Supplier`

  constructor() { }

  getById(id: string) {
    return this._http.get(`${this.apiSupplier}/${id}`);
  }

  createItem(data: any): Observable<any> {
    return this._http.post(this.apiSupplier, data);
  }

  updateItem(id: string, data: any): Observable<any> {
    return this._http.put(`${this.apiSupplier}/${id}`, data);
  }

  filter(filters: ISupplierFilterInput): Observable<ISupplierFilterPagination> {
    const params = new HttpParams()
      .set('search', filters.search ?? '' )
      .set('pageNumber', filters.pageNumber ?? 1)
      .set('pageSize', filters.pageSize ?? 12);

    return this._http.get<ISupplierFilterPagination>(`${this.apiSupplier}/filter`, {params});
  }

  deleteItem(id: string): Observable<any> {
    return this._http.delete(`${this.apiSupplier}/${id}`);
  }

  disableItem(idInput: string, isDisableItem: boolean): Observable<any> {
    return this._http.post(`${this.apiSupplier}/disable`, { id: idInput, isDisable: isDisableItem });
  }
}
