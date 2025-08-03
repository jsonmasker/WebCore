import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthenticationService } from './authentication.service';
import { EUrl } from '@common/url-api';
import { catchError, Observable, switchMap, throwError } from 'rxjs';
import { APIResponse } from '@models/api-response.model';
import { Pagination } from '@models/pagination.model';
import { ActionLoggingModel } from '@models/system-management-models/action-logging.model';


@Injectable({
  providedIn: 'root'
})
export class ActionLoggingService {

  constructor(private http: HttpClient, private authenticationService: AuthenticationService) { }

  getAll(query: any): Observable<APIResponse<Pagination<ActionLoggingModel>>> {
    return this.http.get<APIResponse<Pagination<ActionLoggingModel>>>(EUrl.getAllUrlActionLogging, { headers: this.authenticationService.GetHeaders(), params: query }).pipe(
      catchError(error => {
        if (error.status === 401) {
          return this.authenticationService.ReNewToken().pipe(
            switchMap(() => this.http.get<APIResponse<Pagination<ActionLoggingModel>>>(EUrl.getAllUrlActionLogging, { headers: this.authenticationService.GetHeaders(), params: query }))
          );
        } else {
          return throwError(error);
        }
      })
    );
  }

  getById(id: any): Observable<APIResponse<ActionLoggingModel>> {
    return this.http.get<APIResponse<ActionLoggingModel>>(EUrl.getByIdUrlActionLogging + `/${id}`, { headers: this.authenticationService.GetHeaders() }).pipe(
      catchError(error => {
        if (error.status === 401) {
          return this.authenticationService.ReNewToken().pipe(
            switchMap(() => this.http.get<APIResponse<ActionLoggingModel>>(EUrl.getByIdUrlActionLogging + `/${id}`, { headers: this.authenticationService.GetHeaders() }))
          );
        } else {
          return throwError(error);
        }
      })
    );
  }
}
