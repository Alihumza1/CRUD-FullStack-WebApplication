import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Service } from 'src/app/services/service';
import { Router } from '@angular/router';
import { createEmployee } from 'src/app/models/employeeModel';
@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css'],
})
export class AddComponent implements OnInit {
  constructor(private service: Service, private router: Router) {}
  departments: any[] = [];
  employees: any[] = [];
  ngOnInit(): void {
    this.service.getAllDepartments().subscribe((data: any[]) => {
      this.departments = data;
    });
    this.service.getAllEmployee().subscribe((data: any[]) => {
      this.employees = data;
    });
  }
  addEmployee = new FormGroup({
    name: new FormControl('', [
      Validators.required,
      Validators.pattern('[a-zA-Z ]*'),
      Validators.minLength(1),
      Validators.maxLength(14),
    ]),
    depid: new FormControl('', [Validators.required]),
    manager: new FormControl('', [Validators.required]),
    cnic: new FormControl('', [
      Validators.required,
      Validators.pattern('[0-9]*'),
      Validators.minLength(13),
      Validators.maxLength(13),
    ]),
    age: new FormControl('', [
      Validators.required,
      Validators.pattern('[0-9]*'),
      Validators.min(18),
      Validators.max(59),
    ]),
    salary: new FormControl('', [
      Validators.required,
      Validators.pattern('[0-9]*'),
      Validators.min(10000),
      Validators.max(100000),
    ]),
  });
  Submit(): void {
    const employee: createEmployee = {
      name: this.addEmployee.get('name')?.value as string,
      manager: this.addEmployee.get('manager')?.value as string,
      age: parseInt(this.addEmployee.get('age')?.value || ''),
      salary: parseInt(this.addEmployee.get('salary')?.value || ''),
      cnic: this.addEmployee.get('cnic')?.value as string,
      depId: parseInt(this.addEmployee.get('depid')?.value || ''),
    };
    this.service.addEmployee(employee).subscribe(
      (resp) => {
        this.router.navigate(['pages/home']);
      },
      (error) => {
        alert('Unsuccessful !');
      }
    );
  }
  get name(): FormControl {
    return this.addEmployee.get('name') as FormControl;
  }
  get manager(): FormControl {
    return this.addEmployee.get('manager') as FormControl;
  }
  get depid(): FormControl {
    return this.addEmployee.get('depid') as FormControl;
  }
  get cnic(): FormControl {
    return this.addEmployee.get('cnic') as FormControl;
  }
  get age(): FormControl {
    return this.addEmployee.get('age') as FormControl;
  }
  get salary(): FormControl {
    return this.addEmployee.get('salary') as FormControl;
  }
}
