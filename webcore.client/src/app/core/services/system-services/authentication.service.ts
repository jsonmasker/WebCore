import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, Observable } from 'rxjs';
import { EUrl } from '@common/url-api';
import { JwtModel } from '@models/system-management-models/jwt.model';
import { jwtDecode } from 'jwt-decode';
import { APIResponse } from '@models/api-response.model';
@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private http: HttpClient) { }

  CheckLogin(): Observable<boolean> {
    const refreshToken = localStorage.getItem('refreshToken');
    if (!refreshToken) {
      return new Observable<boolean>(observer => {
        observer.next(false);
        observer.complete();
      });
    }
    const headers = new HttpHeaders().set('refreshToken',refreshToken);
    
    return new Observable<boolean>(observer => {
      this.http.get(EUrl.validateRefreshTokenUrl,{headers}).subscribe({
        next: () => {       
          observer.next(true);
          observer.complete();
        },
        error: () => {
          observer.next(false);
          observer.complete();
        }
      });
    });
  }
  LogOut():void {
    localStorage.removeItem('token');
    localStorage.removeItem('refreshToken');
  }
  GetAccessToken():any {
    return localStorage.getItem('token');
  }
  ReNewToken(): Observable<any> {
    const refreshToken = localStorage.getItem('refreshToken');
    const token = localStorage.getItem('token');
    if (!refreshToken || !token) {
      return new Observable(observer => {
        observer.next(false);
        observer.complete();
      });
    }
    const headers = new HttpHeaders().set('refreshToken', refreshToken).set('token', token);
    return this.http.get<APIResponse<JwtModel>>(EUrl.reNewToken, { headers }).pipe(
      map((result) => {
        
        localStorage.setItem('token', result.data.token);
        return result;
      })
    );
  }
  GetHeaders(): HttpHeaders {
    const token = this.GetAccessToken();
    return new HttpHeaders().set('Authorization', `Bearer ${token}`);
  }
  getUserId(): any {
    const token = localStorage.getItem('token');
    if (token) {
      const claims = jwtDecode<any>(token);
      return claims?.Id;
    }
    return null;
  }  
}
