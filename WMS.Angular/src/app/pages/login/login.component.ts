import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { IconComponent } from '../../shared/components/icon/icon.component';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule, IconComponent],
  templateUrl: './login.component.html',
  styles: [`
    .form-input:focus { border-color: #3b82f6 !important; }
  `]
})
export class LoginComponent {
  email = 'admin@skybest.com';
  password = '••••••••';
  showPass = false;
  loading = false;
  stats = [["1,341", "Pallets Tracked"], ["5", "Warehouses"], ["99.2%", "Accuracy"]];

  constructor(private router: Router) {}

  handleLogin() {
    this.loading = true;
    setTimeout(() => {
      this.loading = false;
      this.router.navigate(['/home']);
    }, 900);
  }
}