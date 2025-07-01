import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { IManufacturerFilterInput, IManufacturerFilterPagination } from '../models/manufacturer';

@Injectable({
  providedIn: 'root'
})
export class ManufacturerService {

  private _http = inject(HttpClient);
  apiManufacturer = `${environment.apiUrl}/Manufacturer`

  constructor() { }

  getById(id: string) {
    return this._http.get(`${this.apiManufacturer}/${id}`);
  }

  createItem(data: any): Observable<any> {
    return this._http.post(this.apiManufacturer, data);
  }

  updateItem(id: string, data: any): Observable<any> {
    return this._http.put(`${this.apiManufacturer}/${id}`, data);
  }

  filter(filters: IManufacturerFilterInput): Observable<IManufacturerFilterPagination> {
    const params = new HttpParams()
      .set('search', filters.search ?? '' )
      .set('pageNumber', filters.pageNumber ?? 1)
      .set('pageSize', filters.pageSize ?? 12);

    return this._http.get<IManufacturerFilterPagination>(`${this.apiManufacturer}/filter`, {params});
  }

  deleteItem(id: string): Observable<any> {
    return this._http.delete(`${this.apiManufacturer}/${id}`);
  }

  disableItem(idInput: string, isDisableItem: boolean): Observable<any> {
    return this._http.post(`${this.apiManufacturer}/disable`, { id: idInput, isDisable: isDisableItem });
  }
}
