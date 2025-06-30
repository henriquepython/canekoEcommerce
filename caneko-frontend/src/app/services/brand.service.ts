import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { IBrandFilterInput, IBrandFilterPagination } from '../models/brand';

@Injectable({
  providedIn: 'root'
})
export class BrandService {

  private _http = inject(HttpClient);
  apiBrand = `${environment.apiUrl}/Brand`

  constructor() { }

  getById(id: string) {
    return this._http.get(`${this.apiBrand}/${id}`);
  }

  createItem(data: any): Observable<any> {
    return this._http.post(this.apiBrand, data);
  }

  updateItem(id: string, data: any): Observable<any> {
    return this._http.put(`${this.apiBrand}/${id}`, data);
  }

  filter(filters: IBrandFilterInput): Observable<IBrandFilterPagination> {
    const params = new HttpParams()
      .set('search', filters.search ?? '' )
      .set('pageNumber', filters.pageNumber ?? 1)
      .set('pageSize', filters.pageSize ?? 12);

    return this._http.get<IBrandFilterPagination>(`${this.apiBrand}/filter`, {params});
  }

  deleteItem(id: string): Observable<any> {
    return this._http.delete(`${this.apiBrand}/${id}`);
  }

  disableItem(idInput: string, isDisableItem: boolean): Observable<any> {
    return this._http.post(`${this.apiBrand}/disable`, { id: idInput, isDisable: isDisableItem });
  }
}
