import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Service } from '../services/service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  constructor(private service: Service, private router: Router) {}
  ngOnInit(): void {}
  loginForm = new FormGroup({
    inputEmail: new FormControl('', [Validators.required, Validators.email]),
    inputPassword: new FormControl('', [
      Validators.required,
      Validators.minLength(8),
      Validators.maxLength(14),
    ]),
  });
  Submitted() {
    this.service
      .loginUser([
        this.loginForm.value.inputEmail as string,
        this.loginForm.value.inputPassword as string,
      ])
      .subscribe(
        (resp) => {
          const respObj = JSON.parse(resp);
          this.router.navigate(['pages/home']);
          localStorage.setItem('token', respObj.token);
          alert('Successfully Login');
        },
        (error) => {
          alert('Username or Password is incorrect !');
        }
      );
  }
  get Email(): FormControl {
    return this.loginForm.get('inputEmail') as FormControl;
  }
  get PWD(): FormControl {
    return this.loginForm.get('inputPassword') as FormControl;
  }
}
