import { HttpInterceptorFn, HttpResponse } from '@angular/common/http';
import { inject } from '@angular/core';
import { concat, of } from 'rxjs';
import { tap } from 'rxjs/operators';
import { RequestCacheService } from '../services/request-cache.service';

export const cacheInterceptor: HttpInterceptorFn = (req, next) => {
  const cache = inject(RequestCacheService);

  // Invalidate cache when creating, updating, or deleting data
  if (req.method !== 'GET') {
    cache.clear();
    return next(req);
  }

  const cachedResponse = cache.get(req);

  // Network observable that updates the cache upon arrival
  const network$ = next(req).pipe(
    tap(event => {
      if (event instanceof HttpResponse) {
        cache.put(req, event);
      }
    })
  );

  // Stale-While-Revalidate: emit cached response first, then background network fetch
  if (cachedResponse) {
    return concat(of(cachedResponse), network$);
  }

  return network$;
};