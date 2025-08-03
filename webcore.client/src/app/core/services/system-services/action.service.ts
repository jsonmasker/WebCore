import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, switchMap, throwError } from 'rxjs';
import { EUrl } from '@common/url-api';
import { AuthenticationService } from './authentication.service';
import { APIResponse, BaseAPIResponse } from '@models/api-response.model';
import { Pagination } from '@models/pagination.model';
import { ActionModel } from '@models/system-management-models/module.model';
@Injectable({
  providedIn: 'root'
})
export class ActionService {
  constructor(private http: HttpClient, private authenticationService: AuthenticationService) { }
   getAll(pageIndex :number, pageSize : number): Observable<APIResponse<Pagination<ActionModel>>> {
      return this.http.get<APIResponse<Pagination<ActionModel>>>(EUrl.getAllUrlAction + `/${pageIndex}/${pageSize}`, { headers: this.authenticationService.GetHeaders() }).pipe(
        catchError(error => {
          if (error.status === 401) {
            return this.authenticationService.ReNewToken().pipe(
              switchMap(() => this.http.get<APIResponse<Pagination<ActionModel>>>(EUrl.getAllUrlAction + `/${pageIndex}/${pageSize}` , { headers: this.authenticationService.GetHeaders() }))
            );
          } else {
            return throwError(error);
          }
        })
      );
    }

    getAllActive(): Observable<APIResponse<ActionModel[]>> {
      return this.http.get<APIResponse<ActionModel[]>>(EUrl.getAllActiveUrlAction , { headers: this.authenticationService.GetHeaders() }).pipe(
        catchError(error => {
          if (error.status === 401) {
            return this.authenticationService.ReNewToken().pipe(
              switchMap(() => this.http.get<APIResponse<ActionModel[]>>(EUrl.getAllActiveUrlAction  , { headers: this.authenticationService.GetHeaders() }))
            );
          } else {
            return throwError(error);
          }
        })
      );
    }

    getEAction(): Observable<APIResponse<any[]>> {
      return this.http.get<APIResponse<any[]>>(EUrl.getEActionUrlAction , { headers: this.authenticationService.GetHeaders() }).pipe(
        catchError(error => {
          if (error.status === 401) {
            return this.authenticationService.ReNewToken().pipe(
              switchMap(() => this.http.get<APIResponse<any[]>>(EUrl.getEActionUrlAction , { headers: this.authenticationService.GetHeaders() }))
            );
          } else {
            return throwError(error);
          }
        })
      );
    }
    create(data: FormData): Observable<BaseAPIResponse> {
      return this.http.post<BaseAPIResponse>(EUrl.createUrlAction, data, { headers: this.authenticationService.GetHeaders() }).pipe(
        catchError(error => {
          if (error.status === 401) {
            return this.authenticationService.ReNewToken().pipe(
              switchMap(() => this.http.post<BaseAPIResponse>(EUrl.createUrlAction, data, { headers: this.authenticationService.GetHeaders() }))
            );
          } else {
            return throwError(error);
          }
        })
      );
    }
    getById(id: number): Observable<APIResponse<ActionModel>> {
      return this.http.get<APIResponse<ActionModel>>(EUrl.getByIdUrlAction +  `/${id}`, { headers: this.authenticationService.GetHeaders() }).pipe(
        catchError(error => {
          if (error.status === 401) {
            return this.authenticationService.ReNewToken().pipe(
              switchMap(() => this.http.get<APIResponse<ActionModel>>(EUrl.getByIdUrlAction +  `/${id}`, { headers: this.authenticationService.GetHeaders() }))
            );
          } else {
            return throwError(error);
          }
        })
      );
    }

    update(data: ActionModel): Observable<BaseAPIResponse> {
      return this.http.put<BaseAPIResponse>(EUrl.updateUrlAction, data, { headers: this.authenticationService.GetHeaders() }).pipe(
        catchError(error => {
          if (error.status === 401) {
            return this.authenticationService.ReNewToken().pipe(
              switchMap(() => this.http.put<BaseAPIResponse>(EUrl.updateUrlAction, data, { headers: this.authenticationService.GetHeaders() }))
            );
          } else {
            return throwError(error);
          }
        })
      );
    }
}
