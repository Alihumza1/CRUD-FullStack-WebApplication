import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { Service } from './service';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
  constructor(private auth: Service, private router: Router) {}
  canActivate() {
    if (this.auth.IsloggedIn()) {
      return true;
    } else {
      this.router.navigate(['']);
      return false;
    }
  }
}
