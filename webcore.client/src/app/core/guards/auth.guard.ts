import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthenticationService } from '../services/system-services/authentication.service';

export const authGuard: CanActivateFn = async () => {
  const auth: AuthenticationService = inject(AuthenticationService);
  const router: Router = inject(Router);
return await auth.CheckLogin().toPromise().then((isAuthenticated) => {
  if (!isAuthenticated) {
    return true; // Allow access to the login page
  }
  router.navigate(['./introduction']);
  return false; // Block access to the login page
}).catch(() => {
  return true; // Allow access in case of error
});
};
