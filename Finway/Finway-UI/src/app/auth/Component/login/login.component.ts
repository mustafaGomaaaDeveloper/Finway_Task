import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { loginModel } from '../../Model/Loginmodel';
import { AuthService } from '../../Services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;
  user!: loginModel;
  loading = false;
  error = false;
  lablestring = 'Sign in';

  constructor(
    private fb: FormBuilder,
    private service: AuthService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.createForm();
  }

  createForm() {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: [
        '',
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(20),
        ],
      ],
    });
  }

  login() {
    this.lablestring = '';
    this.loading = true;
    this.user = this.loginForm.value;
    console.log(this.user);
    this.service.loginService(this.user).subscribe(
      (res: any) => {
        (this.loading = false), (this.error = false);
        this.lablestring = 'Sign in';
        console.log('success');
        this.router.navigate(['/']);
      },
      (error) => {
        this.loading = false;
        this.error = true;
        console.log(error);
        this.lablestring = 'Sign in';
      }
    );
  }
}
