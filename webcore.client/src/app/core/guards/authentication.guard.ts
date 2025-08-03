import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthenticationService } from '../services/system-services/authentication.service';

export const authenticationGuard: CanActivateFn  = async () => {
  const auth: AuthenticationService = inject(AuthenticationService);
  const router: Router = inject(Router);
return await auth.CheckLogin().toPromise().then((isAuthenticated) => {
  if (isAuthenticated) {
    return true; // Allow access to the home page
  }
  router.navigate(['./login']);
  return false; // Block access to the 404 page
}).catch(() => {
  router.navigate(['./404']);
  return false; // Block access to the 404 page
});
};
