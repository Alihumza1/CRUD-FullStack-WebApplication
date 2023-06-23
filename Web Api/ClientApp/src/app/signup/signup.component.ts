import { Component, OnInit } from '@angular/core';
import {
  FormGroup,
  FormBuilder,
  FormArray,
  FormControl,
  Validators,
} from '@angular/forms';
import { Service } from '../services/service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css'],
})
export class SignupComponent implements OnInit {
  constructor(private signin: Service, private router: Router) {}

  ngOnInit(): void {}
  signinForm = new FormGroup({
    inputEmail: new FormControl('', [Validators.required, Validators.email]),
    inputPassword: new FormControl('', [
      Validators.required,
      Validators.minLength(8),
      Validators.maxLength(14),
    ]),
  });
  isUserValid: boolean = false;
  Submitted() {
    this.signin
      .signinUser([
        this.signinForm.value.inputEmail as string,
        this.signinForm.value.inputPassword as string,
      ])
      .subscribe(
        (resp) => {
          alert('Account Created ');
          this.router.navigate(['pages/home']);
        },
        (error) => {
          alert('Unsuccesful');
        }
      );
  }

  get Email(): FormControl {
    return this.signinForm.get('inputEmail') as FormControl;
  }
  get PWD(): FormControl {
    return this.signinForm.get('inputPassword') as FormControl;
  }
}
