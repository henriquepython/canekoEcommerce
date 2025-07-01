import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { IRecommendFilterInput, IRecommendFilterPagination } from '../models/recommend';

@Injectable({
  providedIn: 'root'
})
export class RecommendService {

  private _http = inject(HttpClient);
  apiRecommend = `${environment.apiUrl}/Recommend`

  constructor() { }

  getById(id: string) {
    return this._http.get(`${this.apiRecommend}/${id}`);
  }

  createItem(data: any): Observable<any> {
    return this._http.post(this.apiRecommend, data);
  }

  updateItem(id: string, data: any): Observable<any> {
    return this._http.put(`${this.apiRecommend}/${id}`, data);
  }

  filter(filters: IRecommendFilterInput): Observable<IRecommendFilterPagination> {
    const params = new HttpParams()
      .set('search', filters.search ?? '' )
      .set('pageNumber', filters.pageNumber ?? 1)
      .set('pageSize', filters.pageSize ?? 12);

    return this._http.get<IRecommendFilterPagination>(`${this.apiRecommend}/filter`, {params});
  }

  deleteItem(id: string): Observable<any> {
    return this._http.delete(`${this.apiRecommend}/${id}`);
  }

  disableItem(idInput: string, isDisableItem: boolean): Observable<any> {
    return this._http.post(`${this.apiRecommend}/disable`, { id: idInput, isDisable: isDisableItem });
  }
}
