import { Component, OnInit, ViewChild } from '@angular/core';
import { DataTableDirective } from 'angular-datatables';
import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';
import { Service } from 'src/app/services/service';
@Component({
  selector: 'app-home',
  templateUrl: './dephome.component.html',
})
export class DephomeComponent implements OnInit {
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
          .post('https://cruddapp.azurewebsites.net/api/Department', dataTablesParameters)
          .subscribe((Response: any) => {
            callback({
              recordsTotal: Response.recordsTotal,
              recordsFiltered: Response.recordsFiltered,
              data: Response.data,
            });
          });
      },
      columns: [
        { title: 'Depid', data: 'depid', visible: false, orderable: false },
        { title: 'Department Name', data: 'name' },
        { title: 'Head Name', data: 'headName' },
        { title: 'Location', data: 'location' },
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
          targets: [3],
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
            this._router.navigate(['pages/depedit'], {
              queryParams: { depid: data.depid },
            });
          });
        }
        const deleteButton = (row as HTMLElement).querySelector('.delete');
        if (deleteButton) {
          deleteButton.addEventListener('click', () => {
            const id = data.depid;
            const name = data.name;
            const confirmDelete = confirm(
              'Are you sure you want to delete the Record of ' + name
            );
            if (confirmDelete) {
              this.service.deleteDepartment(id).subscribe(
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
