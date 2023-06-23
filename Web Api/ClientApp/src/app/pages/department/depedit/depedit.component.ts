import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Service } from 'src/app/services/service';
import { ActivatedRoute, Router } from '@angular/router';
import { editEmployee } from 'src/app/models/employeeModel';
import { editDepartment } from 'src/app/models/departmentModel';
@Component({
  selector: 'app-edit',
  templateUrl: './depedit.component.html',
  styleUrls: ['./depedit.component.css'],
})
export class DepeditComponent implements OnInit {
  constructor(
    private service: Service,
    private router: Router,
    private Router: ActivatedRoute
  ) {}
  employees: any[] = [];
  ngOnInit(): void {
    this.service.getAllEmployee().subscribe((data: any[]) => {
      this.employees = data;
    });
    const id = this.Router.snapshot.queryParams.depid;
    this.service.getDepartmentbyid(id).subscribe((data: any) => {
      this.editDepartment.patchValue({
        name: data.name,
        depid: data.depid,
        headname: data.headName,
        location: data.location,
      });
    });
  }
  editDepartment = new FormGroup({
    name: new FormControl('', [
      Validators.required,
      Validators.pattern('[a-zA-Z ]*'),
      Validators.minLength(2),
      Validators.maxLength(25),
    ]),
    depid: new FormControl('', [Validators.required]),
    headname: new FormControl('', [Validators.required]),
    location: new FormControl('', [
      Validators.required,
      Validators.pattern('[a-zA-Z ]*'),
      Validators.minLength(2),
      Validators.maxLength(25),
    ]),
  });
  Submit() {
    const department: editDepartment = {
      depId: parseInt(this.editDepartment.get('depid')?.value || ''),
      name: this.editDepartment.get('name')?.value as string,
      headName: this.editDepartment.get('headname')?.value as string,
      location: this.editDepartment.get('location')?.value as string,
    };
    this.service.updateDepartment(department).subscribe(
      (resp) => {
        this.router.navigate(['pages/dephome']);
      },
      (error) => {
        alert('Unsuccessful !');
      }
    );
  }

  get depid(): FormControl {
    return this.editDepartment.get('depid') as FormControl;
  }
  get name(): FormControl {
    return this.editDepartment.get('name') as FormControl;
  }
  get headname(): FormControl {
    return this.editDepartment.get('headname') as FormControl;
  }
  get location(): FormControl {
    return this.editDepartment.get('location') as FormControl;
  }
}
