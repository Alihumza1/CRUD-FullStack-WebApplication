import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Service } from 'src/app/services/service';
import { Router } from '@angular/router';
import { createDepartment } from 'src/app/models/departmentModel';
@Component({
  selector: 'app-add',
  templateUrl: './depadd.component.html',
  styleUrls: ['./depadd.component.css'],
})
export class DepaddComponent implements OnInit {
  constructor(private service: Service, private router: Router) {}
  employees: any[] = [];
  ngOnInit(): void {
    this.service.getAllEmployee().subscribe((data: any[]) => {
      this.employees = data;
    });
  }
  addDepartment = new FormGroup({
    name: new FormControl('', [
      Validators.required,
      Validators.pattern('[a-zA-Z ]*'),
      Validators.minLength(2),
      Validators.maxLength(25),
    ]),
    headname: new FormControl('', [Validators.required]),
    location: new FormControl('', [
      Validators.required,
      Validators.pattern('[a-zA-Z ]*'),
      Validators.minLength(2),
      Validators.maxLength(25),
    ]),
  });
  Submit(): void {
    const department: createDepartment = {
      name: this.addDepartment.get('name')?.value as string,
      headName: this.addDepartment.get('headname')?.value as string,
      location: this.addDepartment.get('location')?.value as string,
    };
    this.service.addDepartment(department).subscribe(
      (resp) => {
        this.router.navigate(['pages/dephome']);
      },
      (error) => {
        alert('Unsuccessful !');
      }
    );
  }
  get name(): FormControl {
    return this.addDepartment.get('name') as FormControl;
  }
  get headname(): FormControl {
    return this.addDepartment.get('headname') as FormControl;
  }
  get location(): FormControl {
    return this.addDepartment.get('location') as FormControl;
  }
}
