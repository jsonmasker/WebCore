import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, switchMap, throwError } from 'rxjs';
import { AccountModel } from '@models/system-management-models/account.model';
import { EUrl } from '@common/url-api';
import { AuthenticationService } from './authentication.service';
import { APIResponse, BaseAPIResponse } from '@models/api-response.model';
import { Pagination } from '@models/pagination.model';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor(private http: HttpClient, private authenticationService: AuthenticationService) { }

  getAll(pageIndex: number, pageSize: number): Observable<APIResponse<Pagination<AccountModel>>> {
    return this.http.get<APIResponse<Pagination<AccountModel>>>(EUrl.getAllUrlAccount + `/${pageIndex}/${pageSize}`, { headers: this.authenticationService.GetHeaders() }).pipe(
      catchError(error => {
        if (error.status === 401) {
          return this.authenticationService.ReNewToken().pipe(
            switchMap(() => this.http.get<APIResponse<Pagination<AccountModel>>>(EUrl.getAllUrlAccount + `/${pageIndex}/${pageSize}`, { headers: this.authenticationService.GetHeaders() }))
          );
        } else {
          return throwError(error);
        }
      })
    );
  }

  getAccountById(id: number): Observable<APIResponse<AccountModel>> {
    return this.http.get<APIResponse<AccountModel>>(`${EUrl.getByIdUrlAccount}${id}`, { headers: this.authenticationService.GetHeaders() }).pipe(
      catchError(error => {
        if (error.status === 401) {
          return this.authenticationService.ReNewToken().pipe(
            switchMap(() => this.http.get<APIResponse<AccountModel>>(`${EUrl.getByIdUrlAccount}${id}`, { headers: this.authenticationService.GetHeaders() }))
          );
        } else {
          return throwError(error);
        }
      })
    );
  }

  createAccount(account: AccountModel): Observable<BaseAPIResponse> {
    return this.http.post<BaseAPIResponse>(EUrl.createUrlAccount, account, { headers: this.authenticationService.GetHeaders() }).pipe(
      catchError(error => {
        if (error.status === 401) {
          return this.authenticationService.ReNewToken().pipe(
            switchMap(() => this.http.post<BaseAPIResponse>(EUrl.createUrlAccount, account, { headers: this.authenticationService.GetHeaders() }))
          );
        } else {
          return throwError(error);
        }
      })
    );
  }

  updateAccount(account: AccountModel): Observable<BaseAPIResponse> {
    return this.http.put<BaseAPIResponse>(EUrl.updateUrlAccount, account, { headers: this.authenticationService.GetHeaders() }).pipe(
      catchError(error => {
        if (error.status === 401) {
          return this.authenticationService.ReNewToken().pipe(
            switchMap(() => this.http.put<BaseAPIResponse>(EUrl.updateUrlAccount, account, { headers: this.authenticationService.GetHeaders() }))
          );
        } else {
          return throwError(error);
        }
      })
    );
  }

  // deleteAccount(id: number): Observable<any> {
  //   return this.http.delete<any>(EUrl.deleteUrlAccount + id);
  // }

}
