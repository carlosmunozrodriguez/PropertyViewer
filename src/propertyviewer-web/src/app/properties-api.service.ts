import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PropertiesApiService {

  constructor(private _httpClient: HttpClient) { }

  get() : Observable<Property[]> {
    return this._httpClient.get<Property[]>(`${environment.backEndUrl}/properties`)
  }
}
