import { Injectable } from '@angular/core';
import { SettingModel } from '@models/system-management-models/setting.model';
import { EUrl } from '../../common/url-api';
import { catchError, Observable, switchMap, throwError } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { AuthenticationService } from './authentication.service';

@Injectable({
  providedIn: 'root'
})
export class SettingService {

  constructor(private http: HttpClient, private authenticationService: AuthenticationService) { }

  getAllSettings(): Observable<SettingModel[]> {
    return this.http.get<SettingModel[]>(EUrl.getAllUrlSetting, { headers: this.authenticationService.GetHeaders() }).pipe(
      catchError(error => {
        if (error.status === 401) {
          return this.authenticationService.ReNewToken().pipe(
            switchMap(() => this.http.get<SettingModel[]>(EUrl.getAllUrlSetting, { headers: this.authenticationService.GetHeaders() }))
          );
        } else {
          return throwError(error);
        }
      })
    );
  }

  getSettingByKey(key: any): Observable<SettingModel> {
    return this.http.get<SettingModel>(EUrl.getByKeyUrlSetting + `/${key}`, { headers: this.authenticationService.GetHeaders() }).pipe(
      catchError(error => {
        if (error.status === 401) {
          return this.authenticationService.ReNewToken().pipe(
            switchMap(() => this.http.get<SettingModel>(EUrl.getByKeyUrlSetting + `/${key}`, { headers: this.authenticationService.GetHeaders() }))
          );
        } else {
          return throwError(error);
        }
      })
    );
  }

  updateSetting(setting: SettingModel): Observable<SettingModel> {
    return this.http.put<SettingModel>(EUrl.updateUrlSetting, setting, { headers: this.authenticationService.GetHeaders() }).pipe(
      catchError(error => {
        if (error.status === 401) {
          return this.authenticationService.ReNewToken().pipe(
            switchMap(() => this.http.put<SettingModel>(EUrl.updateUrlSetting, setting, { headers: this.authenticationService.GetHeaders() }))
          );
        } else {
          return throwError(error);
        }
      })
    );
  }
}
