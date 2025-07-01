import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { IColorItemFilterInput, IColorItemFilterPagination } from '../models/colorItem';

@Injectable({
  providedIn: 'root'
})
export class ColorItemService {

  private _http = inject(HttpClient);
  apiColorItem = `${environment.apiUrl}/ColorItem`

  constructor() { }

  getById(id: string) {
    return this._http.get(`${this.apiColorItem}/${id}`);
  }

  createItem(data: any): Observable<any> {
    return this._http.post(this.apiColorItem, data);
  }

  updateItem(id: string, data: any): Observable<any> {
    return this._http.put(`${this.apiColorItem}/${id}`, data);
  }

  filter(filters: IColorItemFilterInput): Observable<IColorItemFilterPagination> {
    const params = new HttpParams()
      .set('search', filters.search ?? '' )
      .set('pageNumber', filters.pageNumber ?? 1)
      .set('pageSize', filters.pageSize ?? 12);

    return this._http.get<IColorItemFilterPagination>(`${this.apiColorItem}/filter`, {params});
  }

  deleteItem(id: string): Observable<any> {
    return this._http.delete(`${this.apiColorItem}/${id}`);
  }

  disableItem(idInput: string, isDisableItem: boolean): Observable<any> {
    return this._http.post(`${this.apiColorItem}/disable`, { id: idInput, isDisable: isDisableItem });
  }
}
