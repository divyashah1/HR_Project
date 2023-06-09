import { Component, OnInit } from '@angular/core';
import { IEmployee } from '../iemployee';
import { EmployeeService } from '../employee.service';
import { Router } from '@angular/router';
import { PagingConfig } from '../paging-config';
@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {

  employee;
  id: any;
  column: any[] = [];
  currentPage:number  = 1;
  itemsPerPage: number = 7;
  totalItems: number = 0;

  //column: any[] = ['Name of Employee','City' , 'Mobile', 'Dep_Id', 'Designation_Id' ,'Manager_Id ']

  pagingConfig: PagingConfig = {} as PagingConfig;


  constructor(private ApiService: EmployeeService, private router: Router) { }

  ngOnInit(): void {

    this.ApiService.getall().subscribe({
      next: (x) => {
        this.employee = x.data;
        this.column = Object.keys(x.data[0]);
       
        this.pagingConfig.totalItems = x.length;
        //this.total = x.total;
        console.log(x);
      },
      error: (response) => {
        console.log(response);
      }
    });

    this.pagingConfig = {
      itemsPerPage: this.itemsPerPage,
      currentPage: this.currentPage,
      totalItems: this.totalItems
    }
  }

  delete(id) {
    alert("are you sure , you want to delete selected Employee?");
    // {
    //   this.ApiService.deleteEmployee(id).subscribe(x => {
    //     this.employee = x.data
    //     this.router.navigate(['app-employee']);
    //   })
    // }
    this.employee = this.employee.filter(emp => emp.id != id);
    console.log(this.employee);

  }
  onTableDataChange(event:any){
    this.pagingConfig.currentPage  = event;
    this.ApiService.getall();
  }
  onTableSizeChange(event:any): void {
    this.pagingConfig.itemsPerPage = event.target.value;
    this.pagingConfig.currentPage = 1;
    this.ApiService.getall();
  }
  
}


