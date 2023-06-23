import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './Employees/home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { PagesComponent } from './pages.component';
import { AuthGuard } from '../services/auth.guard';
import { EditComponent } from './Employees/edit/edit.component';
import { AddComponent } from './Employees/add/add.component';
import { DephomeComponent } from './department/dephome/dephome.component';
import { DepeditComponent } from './department/depedit/depedit.component';
import { DepaddComponent } from './department/depadd/depadd.component';

const routes: Routes = [
  {
    path: 'pages',
    component: PagesComponent,
    canActivate: [AuthGuard],
    children: [
      { path: 'home', component: HomeComponent },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'edit', component: EditComponent },
      { path: 'add', component: AddComponent },
      { path: 'dephome', component: DephomeComponent },
      { path: 'depedit', component: DepeditComponent },
      { path: 'depadd', component: DepaddComponent },
    ],
  },
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PagesRoutingModule {}
