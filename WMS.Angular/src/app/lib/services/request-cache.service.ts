import { Injectable } from '@angular/core';
import { HttpRequest, HttpResponse } from '@angular/common/http';

export interface CacheEntry {
  url: string;
  response: HttpResponse<any>;
  entryTime: number;
}

@Injectable({
  providedIn: 'root'
})
export class RequestCacheService {
  private cache = new Map<string, CacheEntry>();
  private readonly maxAgeMs = 1 * 60 * 1000;

  get(req: HttpRequest<any>): HttpResponse<any> | null {
    const url = req.urlWithParams;
    const cached = this.cache.get(url);

    if (!cached) return null;

    const isExpired = Date.now() - cached.entryTime > this.maxAgeMs;
    return isExpired ? null : cached.response;
  }

  put(req: HttpRequest<any>, response: HttpResponse<any>): void {
    const url = req.urlWithParams;
    this.cache.set(url, {
      url,
      response,
      entryTime: Date.now()
    });
  }

  clear(): void {
    this.cache.clear();
  }
}