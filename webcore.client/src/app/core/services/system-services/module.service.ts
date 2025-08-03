import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, switchMap, throwError } from 'rxjs';
import { ModuleModel } from '@models/system-management-models/module.model';
import { EUrl } from '@common/url-api';
import { AuthenticationService } from './authentication.service';

@Injectable({
  providedIn: 'root'
})
export class ModuleService {

  constructor(private http: HttpClient, private authenticationService: AuthenticationService ) { }

  getModules(): Observable<ModuleModel[]> {
    return this.http.get<ModuleModel[]>(EUrl.getAllUrlModule, { headers: this.authenticationService.GetHeaders() }).pipe(
      catchError(error => {
        if (error.status === 401) {
          return this.authenticationService.ReNewToken().pipe(
            switchMap(() => this.http.get<ModuleModel[]>(EUrl.getAllUrlModule, { headers: this.authenticationService.GetHeaders() }))
          );
        } else {
          return throwError(error);
        }
      })
    );
  }
}
