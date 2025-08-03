import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthenticationService } from './authentication.service';
import { catchError, Observable, switchMap, throwError } from 'rxjs';
import { APIResponse } from '@models/api-response.model';
import { ProvinceModel } from '@models/province.model';
import { EUrl } from '@common/url-api';

@Injectable({
  providedIn: 'root'
})
export class ProvinceService {

constructor(private http: HttpClient, private authenticationService: AuthenticationService) { }
  getAll(): Observable<APIResponse<ProvinceModel[]>> {
    return this.http.get<APIResponse<ProvinceModel[]>>(EUrl.getAllUrlProvince, { headers: this.authenticationService.GetHeaders() }).pipe(
      catchError(error => {
        if (error.status === 401) {
          return this.authenticationService.ReNewToken().pipe(
            switchMap(() => this.http.get<APIResponse<ProvinceModel[]>>(EUrl.getAllUrlProvince, { headers: this.authenticationService.GetHeaders() }))
          );
        } else {
          return throwError(() => error);
        }
      })
    );
  }
  
}

