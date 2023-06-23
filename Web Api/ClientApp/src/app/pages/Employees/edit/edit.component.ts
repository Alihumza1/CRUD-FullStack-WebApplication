import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Service } from 'src/app/services/service';
import { ActivatedRoute, Router } from '@angular/router';
import { editEmployee } from 'src/app/models/employeeModel';
@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css'],
})
export class EditComponent implements OnInit {
  constructor(
    private service: Service,
    private router: Router,
    private Router: ActivatedRoute
  ) {}
  departments: any[] = [];
  employees: any[] = [];
  ngOnInit(): void {
    this.service.getAllDepartments().subscribe((data: any[]) => {
      this.departments = data;
    });
    this.service.getAllEmployee().subscribe((data: any[]) => {
      this.employees = data;
    });
    const id = this.Router.snapshot.queryParams.id;
    // throw new Error('This is a simulated error.');
    this.service.getEmployeebyid(id).subscribe((data: any) => {
      this.editEmployee.patchValue({
        id: data.id,
        name: data.name,
        manager: data.manager,
        depid: data.depId,
        cnic: data.cnic,
        age: data.age,
        salary: data.salary,
      });
    });
  }
  editEmployee = new FormGroup({
    id: new FormControl('', [Validators.required]),
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

  Submitted() {
    const employee: editEmployee = {
      id: parseInt(this.editEmployee.get('id')?.value || ''),
      name: this.editEmployee.get('name')?.value as string,
      manager: this.editEmployee.get('manager')?.value as string,
      age: parseInt(this.editEmployee.get('age')?.value || ''),
      salary: parseInt(this.editEmployee.get('salary')?.value || ''),
      cnic: this.editEmployee.get('cnic')?.value as string,
      depId: parseInt(this.editEmployee.get('depid')?.value || ''),
    };

    this.service.updateEmployee(employee).subscribe(
      (resp) => {
        this.router.navigate(['pages/home']);
      },
      (error) => {
        alert('Unsuccessful !');
      }
    );
  }
  get id(): FormControl {
    return this.editEmployee.get('id') as FormControl;
  }
  get name(): FormControl {
    return this.editEmployee.get('name') as FormControl;
  }
  get manager(): FormControl {
    return this.editEmployee.get('manager') as FormControl;
  }
  get depid(): FormControl {
    return this.editEmployee.get('depid') as FormControl;
  }
  get cnic(): FormControl {
    return this.editEmployee.get('cnic') as FormControl;
  }
  get age(): FormControl {
    return this.editEmployee.get('age') as FormControl;
  }
  get salary(): FormControl {
    return this.editEmployee.get('salary') as FormControl;
  }
}
