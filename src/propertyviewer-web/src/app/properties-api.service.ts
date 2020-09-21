import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PropertiesApiService {

  constructor(private _httpClient: HttpClient) {
  }

  getProperties() : Observable<Property[]> {
    return this._httpClient.get<Property[]>(`${environment.backEndUrl}/properties`)
  }

  saveProperty(id: number) :Observable<SavePropertyResult> {
    return this._httpClient.post<SavePropertyResult>(`${environment.backEndUrl}/properties/${id}/save`, id);
  }
}
