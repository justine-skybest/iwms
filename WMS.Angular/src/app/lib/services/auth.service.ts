import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { RequestCacheService } from './request-cache.service';
import { environment } from '../config/app-env';
import { LoginRequestDto, UserResponseDto } from '../../api/generated/models';
import { apiAuthLoginPost, apiAuthLogoutPost, apiAuthMeGet } from '../../api/generated/functions';

export interface LoginCredentials {
  email: string;
  password: string;
  rememberMe?: boolean;
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private readonly apiUrl = environment.apiUrl || '';

  // Reactive State for User Context
  private currentUserSubject = new BehaviorSubject<UserResponseDto | null>(null);
  public currentUser$ = this.currentUserSubject.asObservable();

  constructor(
    private http: HttpClient,
    private router: Router,
    private cache: RequestCacheService
  ) {}

  /**
   * Synchronous getter for immediate current user access.
   */
  public get currentUserValue(): UserResponseDto | null {
    return this.currentUserSubject.value;
  }

  /**
   * Authenticates user with Email & Password.
   * Extracts UserResponseDto directly from generated StrictHttpResponse.
   */
  login(credentials: LoginCredentials): Observable<UserResponseDto | null> {
    const loginDto: LoginRequestDto = {
      email: credentials.email,
      password: credentials.password,
      rememberMe: credentials.rememberMe ?? false
    };

    return apiAuthLoginPost(this.http, this.apiUrl, { body: loginDto }).pipe(
      map(response => response.body),
      tap(user => {
        if (user) {
          this.currentUserSubject.next(user);
        }
      }),
      catchError(error => {
        console.error('Login failed:', error);
        return of(null);
      })
    );
  }

  /**
   * Redirects browser to backend Google OAuth challenge route.
   */
  loginWithGoogle(returnUrl: string = '/'): void {
    window.location.href = `${this.apiUrl}/api/auth/google?RETURNURL=${encodeURIComponent(returnUrl)}`;
  }

  /**
   * Logs out user, invalidates cookie session, and clears client cache.
   */
  logout(): Observable<void> {
    return apiAuthLogoutPost(this.http, this.apiUrl).pipe(
      tap(() => this.handleLocalLogout()),
      map(() => void 0),
      catchError(() => {
        this.handleLocalLogout();
        return of(void 0);
      })
    );
  }

  /**
   * Fetches authenticated user details from /api/auth/me using generated client.
   */
  getCurrentUser(): Observable<UserResponseDto | null> {
    return apiAuthMeGet(this.http, this.apiUrl).pipe(
      map(response => response.body),
      tap(user => this.currentUserSubject.next(user)),
      catchError(() => {
        this.currentUserSubject.next(null);
        return of(null);
      })
    );
  }

  /**
   * Alias for getCurrentUser() used by components & guards.
   */
  fetchCurrentUser(): Observable<UserResponseDto | null> {
    return this.getCurrentUser();
  }

  /**
   * Checks whether caller currently holds an active session.
   */
  isAuthenticated(): Observable<boolean> {
    if (this.currentUserValue) {
      return of(true);
    }
    return this.getCurrentUser().pipe(
      map(user => !!user)
    );
  }

  private handleLocalLogout(): void {
    this.cache.clear();
    this.currentUserSubject.next(null);
    this.router.navigate(['/login']);
  }
}