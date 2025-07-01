import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { ICategoryFilterInput, ICategoryFilterPagination } from '../models/category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  private _http = inject(HttpClient);
  apiCategory = `${environment.apiUrl}/Category`

  constructor() { }

  getById(id: string) {
    return this._http.get(`${this.apiCategory}/${id}`);
  }

  createItem(data: any): Observable<any> {
    return this._http.post(this.apiCategory, data);
  }

  updateItem(id: string, data: any): Observable<any> {
    return this._http.put(`${this.apiCategory}/${id}`, data);
  }

  filter(filters: ICategoryFilterInput): Observable<ICategoryFilterPagination> {
    const params = new HttpParams()
      .set('search', filters.search ?? '' )
      .set('pageNumber', filters.pageNumber ?? 1)
      .set('pageSize', filters.pageSize ?? 12);

    return this._http.get<ICategoryFilterPagination>(`${this.apiCategory}/filter`, {params});
  }

  deleteItem(id: string): Observable<any> {
    return this._http.delete(`${this.apiCategory}/${id}`);
  }

  disableItem(idInput: string, isDisableItem: boolean): Observable<any> {
    return this._http.post(`${this.apiCategory}/disable`, { id: idInput, isDisable: isDisableItem });
  }
}
