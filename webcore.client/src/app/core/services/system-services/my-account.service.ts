import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, Observable, switchMap, throwError } from 'rxjs';
import { JwtModel } from '@models/system-management-models/jwt.model';
import { EUrl } from '@common/url-api';
import { ChangePasswordModel } from '@models/system-management-models/change-password.model';
import { AuthenticationService } from './authentication.service';
import { LoginModel } from '@models/system-management-models/login.model';
import { APIResponse, BaseAPIResponse } from '@models/api-response.model';

@Injectable({
  providedIn: 'root'
})
export class MyAccountService {

  constructor(private http: HttpClient, private authenticationService: AuthenticationService) { }

  login(account: LoginModel): Observable<APIResponse<JwtModel>> {
    return this.http.post<APIResponse<JwtModel>>(EUrl.loginUrl, account);
  }

  changePassword(changePasswordModel: ChangePasswordModel): Observable<any> {
    return this.http.post<ChangePasswordModel>(EUrl.changePasswordUrlMyAccount, changePasswordModel, { headers: this.authenticationService.GetHeaders() }).pipe(
      catchError(error => {
        if (error.status === 401) {
          return this.authenticationService.ReNewToken().pipe(
            switchMap(() => this.http.post<ChangePasswordModel>(EUrl.changePasswordUrlMyAccount, changePasswordModel, { headers: this.authenticationService.GetHeaders() }).pipe()));
        } else {
          return throwError(error);
        }
      })
    );
  }
  recoverPassword(email: string): Observable<BaseAPIResponse> {
    return this.http.post<BaseAPIResponse>(EUrl.recoverPasswordUrl, {email});
  }
  resetPassword(token: string, email: string, password: any, confirmPassword:any): Observable<BaseAPIResponse> {
    return this.http.post<BaseAPIResponse>(EUrl.resetPasswordUrl, { token, email, password, confirmPassword });
  }
}
