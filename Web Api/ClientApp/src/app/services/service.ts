import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { createEmployee,editEmployee } from '../models/employeeModel';
import { createDepartment,editDepartment } from '../models/departmentModel';
@Injectable({
  providedIn: 'root',
})
export class Service {
  constructor(private http: HttpClient) {}
  baseServerUrl = 'https://cruddapp.azurewebsites.net/api/';

  updateEmployee(employeeModel: editEmployee): Observable<any[]> {
    return this.http.put<any[]>(this.baseServerUrl + 'Employee/update-Employee-by-id',employeeModel);
  }
  addEmployee(employeeModel: createEmployee): Observable<any[]> {
    return this.http.post<any[]>(this.baseServerUrl + 'Employee/addEmployee', employeeModel);
  }
  getEmployeebyid(id:number): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseServerUrl}Employee/Get-Employee-by-id/${id}`);
  }
  deleteEmployee(id:number): Observable<any[]> { 
    return this.http.delete<any[]>(`${this.baseServerUrl}Employee/Delete-Employee-by-id/${id}`);
  }
  getAllDepartments(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseServerUrl}Department/allDepartments`);
  }
  getAllEmployee(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseServerUrl}Employee/allEmployees`);
  }
  updateDepartment(departmentModel: editDepartment): Observable<any[]> {
    return this.http.put<any[]>(this.baseServerUrl + 'Department/update-Department-by-id',departmentModel);
  }
  addDepartment(departmentModel: createDepartment): Observable<any[]> {
    return this.http.post<any[]>(this.baseServerUrl + 'Department/addDepartment', departmentModel);
  }
  getDepartmentbyid(id:number): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseServerUrl}Department/Get-Department-by-id/${id}`);
  }
  deleteDepartment(id:number): Observable<any[]> { 
    return this.http.delete<any[]>(`${this.baseServerUrl}Department/Delete-Department-by-id/${id}`);
  }
  signinUser(signininfo: Array<string>) {
    return this.http.post(
      this.baseServerUrl + 'Auth/Register',
      {
        UserName: signininfo[0],
        PassWord: signininfo[1],
      },
      {
        responseType: 'text',
      }
    );
  }
  loginUser(logininfo: Array<string>) {
    return this.http.post(
      this.baseServerUrl + 'Auth/Login',
      {
        UserName: logininfo[0],
        PassWord: logininfo[1],
      },
      {
        responseType: 'text',
      }
    );
  }
  IsloggedIn() {
    return !!localStorage.getItem('token');
  }
  IsloggedOut() {
    alert(' Logout Successfully');
    localStorage.removeItem('token');
  }
}
