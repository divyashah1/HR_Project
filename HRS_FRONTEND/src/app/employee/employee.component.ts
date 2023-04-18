import { Component, OnInit } from '@angular/core';
import { IEmployee } from '../iemployee';
import { EmployeeService } from '../employee.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {

  employee;
  id: any;
  col: IEmployee[] = [];
  column: any[] = ['Name of Employee','City' , 'Mobile', 'Dep_Id',
  'Designation_Id' ,'Manager_Id ']
  constructor(private ApiService: EmployeeService, private router: Router) { }

  ngOnInit(): void {

    this.ApiService.getall().subscribe({
      next: (x) => {
        this.employee = x.data;
        console.log(x);
      },
      error: (response) => {
        console.log(response);
      }
    });

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

  t: any = [];
  value: any = [];

  // getdata() {
  //   this.col.forEach((element : any) => {
  //     console.log(element)
  //   });
  // }
}


