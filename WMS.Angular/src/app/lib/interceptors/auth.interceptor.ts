import { HttpInterceptorFn, HttpErrorResponse } from '@angular/common/http';
import { inject } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, throwError } from 'rxjs';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  const router = inject(Router);

  // 1. Attach credentials (cookies) to all requests
  const authReq = req.clone({
    withCredentials: true
  });

  return next(authReq).pipe(
    catchError((error: HttpErrorResponse) => {
      // 2. Ignore 401s originating from /api/auth/* endpoints to avoid redirect loops
      const isAuthEndpoint = req.url.includes('/api/auth/');

      if (error.status === 401 && !isAuthEndpoint) {
        router.navigate(['/login']);
      }

      return throwError(() => error);
    })
  );
};