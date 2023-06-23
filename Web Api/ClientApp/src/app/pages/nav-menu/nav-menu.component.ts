import { Component } from '@angular/core';
import { Service } from 'src/app/services/service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css'],
})
export class NavMenuComponent {
  isExpanded = false;

  constructor(private service: Service, private router: Router) {}

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  logout() {
    console.log('AuthService - logout');
    this.service.IsloggedOut();
    this.router.navigate(['']);
  }
}
