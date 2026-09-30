import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IconComponent } from '../../shared/components/icon/icon.component';
import { AuthService } from '../../lib/services/auth.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule, IconComponent],
  templateUrl: './login.component.html',
  styles: [`
    .form-input:focus { 
      border-color: #2563eb !important; 
      box-shadow: 0 0 0 1px #2563eb !important;
    }
  `]
})
export class LoginComponent implements OnInit {
  email = '';
  password = '';
  rememberMe = false;
  showPass = false;
  loading = false;
  errorMessage = '';
  returnUrl = '/home';

  stats = [
    ['1,341', 'Pallets Tracked'],
    ['5', 'Warehouses'],
    ['99.2%', 'Accuracy']
  ];

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private authService: AuthService
  ) {}

  ngOnInit(): void {
    // 1. Capture returnUrl if set
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/home';

    // 2. Handle Google Login Error (e.g. Non-Skybest domain error)
    const errorParam = this.route.snapshot.queryParams['error'];
    if (errorParam) {
      this.errorMessage = errorParam;
    }

    // 3. Handle Google Login Success Redirect
    const isGoogleSuccess = this.route.snapshot.queryParams['google'] === 'success';
    if (isGoogleSuccess) {
      this.loading = true;
      this.authService.fetchCurrentUser().subscribe({
        next: (user) => {
          this.loading = false;
          if (user) {
            this.router.navigateByUrl(this.returnUrl);
          } else {
            this.errorMessage = 'Session initialization failed after Google sign in.';
          }
        },
        error: () => {
          this.loading = false;
          this.errorMessage = 'Unable to establish authenticated session.';
        }
      });
    }
  }

  handleLogin(): void {
    if (!this.email || !this.password) {
      this.errorMessage = 'Please enter both email address and password.';
      return;
    }

    this.errorMessage = '';
    this.loading = true;

    this.authService.login({
      email: this.email,
      password: this.password,
      rememberMe: this.rememberMe
    }).subscribe({
      next: (user) => {
        this.loading = false;
        if (user) {
          this.router.navigateByUrl(this.returnUrl);
        } else {
          this.errorMessage = 'Invalid email or password. Please verify your credentials.';
        }
      },
      error: (err) => {
        this.loading = false;
        this.errorMessage = err?.error?.message || 'An unexpected error occurred during sign in.';
      }
    });
  }

  handleGoogleLogin(): void {
    this.loading = true;
    this.errorMessage = '';
    this.authService.loginWithGoogle(this.returnUrl);
  }
}