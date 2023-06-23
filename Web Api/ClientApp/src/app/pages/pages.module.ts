import { NgModule, ErrorHandler  } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { DataTablesModule } from 'angular-datatables';

import { PagesComponent } from './pages.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './Employees/home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { EditComponent } from './Employees/edit/edit.component';
import { PagesRoutingModule } from './pages-routing.module';
import { Service } from '../services/service';
import { AuthInterceptor } from '../services/auth.interceptor';
import { AddComponent } from './Employees/add/add.component';
import { DephomeComponent } from './department/dephome/dephome.component';
import { DepaddComponent } from './department/depadd/depadd.component';
import { DepeditComponent } from './department/depedit/depedit.component';
import { GlobalErrorHandler } from 'src/app/services/GlobalErrorHandler';
@NgModule({
  declarations: [
    PagesComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    EditComponent,
    AddComponent,
    DephomeComponent,
    DepaddComponent,
    DepeditComponent,
  ],
  imports: [
    ReactiveFormsModule,
    RouterModule,
    CommonModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    DataTablesModule,
    PagesRoutingModule,
  ],
  providers: [ 
    { provide: ErrorHandler, useClass: GlobalErrorHandler },
    Service,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true,
    },
  ],
})
export class PagesModule {}
