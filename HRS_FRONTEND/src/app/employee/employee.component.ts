import { Component, OnInit } from '@angular/core';
import { IEmployee } from '../iemployee';
import { EmployeeService } from '../employee.service';
@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {

  //employee: any;

  employee: IEmployee[] = [];
  //employeeName: string = "";


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
    //   data => {
    //     this.employee = data;
    //   }
    // );

  }
}
