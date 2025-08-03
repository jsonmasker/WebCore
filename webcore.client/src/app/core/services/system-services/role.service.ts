import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, switchMap, throwError } from 'rxjs';
import { RoleModel } from '@models/system-management-models/role.model';
import { EUrl } from '@common/url-api';
import { AuthenticationService } from './authentication.service';
import { APIResponse, BaseAPIResponse } from '@models/api-response.model';
import { Pagination } from '@models/pagination.model';

@Injectable({
  providedIn: 'root'
})
export class RoleService {

  constructor(private http : HttpClient,private authenticationService: AuthenticationService) { }

  getAll(pageIndex : number, pageSize : Number): Observable<APIResponse<Pagination<RoleModel>>> {
    return this.http.get<APIResponse<Pagination<RoleModel>>>(EUrl.getAllUrlRole + `/${pageIndex}/${pageSize}`, { headers: this.authenticationService.GetHeaders() }).pipe(
      catchError(error => {
        if (error.status === 401) {
          return this.authenticationService.ReNewToken().pipe(
            switchMap(() => this.http.get<APIResponse<Pagination<RoleModel>>>(EUrl.getAllUrlRole+ `/${pageIndex}/${pageSize}`, { headers: this.authenticationService.GetHeaders() }))
          );
        } else {
          return throwError(error);
        }
      })
    );
  }
  getAllActive(): Observable<APIResponse<RoleModel[]>> {
    return this.http.get<APIResponse<RoleModel[]>>(EUrl.getAllActiveUrlRole, { headers: this.authenticationService.GetHeaders() }).pipe(
      catchError(error => {
        if (error.status === 401) {
          return this.authenticationService.ReNewToken().pipe(
            switchMap(() => this.http.get<APIResponse<RoleModel[]>>(EUrl.getAllActiveUrlRole, { headers: this.authenticationService.GetHeaders() }))
          );
        } else {
          return throwError(error);
        }
      })
    );
  }
  getById(id: number): Observable<APIResponse<RoleModel>> {
    return this.http.get<APIResponse<RoleModel>>(EUrl.getByIdUrlRole +`/${id}`, { headers: this.authenticationService.GetHeaders() }).pipe(
      catchError(error => {
        if (error.status === 401) {
          return this.authenticationService.ReNewToken().pipe(
            switchMap(() => this.http.get<APIResponse<RoleModel>>(EUrl.getByIdUrlRole +`/${id}`, { headers: this.authenticationService.GetHeaders() }))
          );
        } else {
          return throwError(error);
        }
      })
    );
  }
  createRole(role: RoleModel): Observable<BaseAPIResponse> {
    return this.http.post<BaseAPIResponse>(EUrl.createUrlRole, role, { headers: this.authenticationService.GetHeaders() }).pipe(
      catchError(error => {
        if (error.status === 401) {
          return this.authenticationService.ReNewToken().pipe(
            switchMap(() => this.http.post<BaseAPIResponse>(EUrl.createUrlRole, role, { headers: this.authenticationService.GetHeaders() }))
          );
        } else {
          return throwError(error);
        }
      })
    );
  }

  updateRole(role: RoleModel): Observable<BaseAPIResponse> {
    return this.http.put<BaseAPIResponse>(EUrl.updateUrlRole, role, { headers: this.authenticationService.GetHeaders() }).pipe(
      catchError(error => {
        if (error.status === 401) {
          return this.authenticationService.ReNewToken().pipe(
            switchMap(() => this.http.put<BaseAPIResponse>(EUrl.updateUrlRole, role, { headers: this.authenticationService.GetHeaders() }))
          );
        } else {
          return throwError(error);
        }
      })
    );
  }

}
