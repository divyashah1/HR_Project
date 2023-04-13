import { Component, OnInit } from '@angular/core';
import { IEmployee } from '../iemployee';
import { EmployeeService } from '../employee.service';
@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {

  employee;
  id: any;

  constructor(private ApiService: EmployeeService) { }

  ngOnInit(): void {

    this.ApiService.getall().subscribe({
      next: (x) => {
        this.employee = x;
        console.log(x);
      },
      error: (response) => {
        console.log(response);
      }
    });

  }

  delete(id:string) {
    this.employee = this.employee.filter(emp=>emp.id != id);
   // console.log(item);
    
  }
}



//  deleteEmployee() {
  //   this.ApiService.deleteEmployee(this.id)
  //     .subscribe((x) => {
  //       this.router.navigate(['app-employees']);
  //     });
  // }