import { Component, OnInit, ViewChild } from '@angular/core';
import { DataTableDirective } from 'angular-datatables';
import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';
import { Service } from 'src/app/services/service';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  @ViewChild(DataTableDirective, { static: false })
  dtElement!: DataTableDirective;
  constructor(
    private route: ActivatedRoute,
    private http: HttpClient,
    private _router: Router,
    private service: Service
  ) {}
  dtOptions: DataTables.Settings = {};
  ngOnInit(): void {
    this.fetchData();
  }
  fetchData() {
    this.dtOptions = {
      processing: true,
      serverSide: true,
      paging: true,
      searching: true,
      ordering: true,
      ajax: (dataTablesParameters: any, callback) => {
        this.http
          .post('https://localhost:7149/api/Employee', dataTablesParameters)
          .subscribe((Response: any) => {
            callback({
              recordsTotal: Response.recordsTotal,
              recordsFiltered: Response.recordsFiltered,
              data: Response.data,
            });
          });
      },
      columns: [
        { title: 'Id', data: 'id', visible: false },
        { title: 'Name', data: 'name' },
        { title: 'Manager', data: 'manager' },
        { title: 'DepId', data: 'depId', visible: false },
        { title: 'Cnic', data: 'cnic' },
        { title: 'Age', data: 'age' },
        { title: 'Salary', data: 'salary' },
        {
          title: 'Actions',
          data: null,
          render: function () {
            return '<button class = "btn btn-success edit">Edit</button>       <button class = "btn btn-danger delete">Delete</button>';
          },
        },
      ],
      columnDefs: [
        {
          targets: [1],
          orderable: true,
          searchable: true,
        },
        {
          targets: [5],
          orderable: true,
        },
        {
          targets: '_all',
          orderable: false,
          searchable: false,
        },
      ],
      rowCallback: (row: Node, data: any, index: number) => {
        const editButton = (row as HTMLElement).querySelector('.edit');
        if (editButton) {
          editButton.addEventListener('click', () => {
            this._router.navigate(['pages/edit'], {
              queryParams: { id: data.id },
            });
          });
        }
        const deleteButton = (row as HTMLElement).querySelector('.delete');
        if (deleteButton) {
          deleteButton.addEventListener('click', () => {
            const id = data.id;
            const name = data.name;
            const confirmDelete = confirm(
              'Are you sure you want to delete the Record of ' + name
            );
            if (confirmDelete) {
              this.service.deleteEmployee(id).subscribe(
                () => {
                  this.dtElement.dtInstance.then(
                    (dtInstance: DataTables.Api) => {
                      dtInstance.ajax.reload();
                    }
                  );
                },
                (error) => {
                  alert('Unsuccessful not deleted');
                }
              );
            }
          });
        }

        return row;
      },
    };
  }
}
