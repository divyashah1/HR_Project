import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AttendanceService } from '../attendance.service';
import { IAttendence } from '../iattendence';
import { EmployeeService } from '../employee.service';

@Component({
  selector: 'app-attendence',
  templateUrl: './attendence.component.html',
  styleUrls: ['./attendence.component.css']
})
export class AttendenceComponent {
  //  date_In : number = Date.now();
  attendance;
  attendanceForm: boolean;
  new: any = {};
  employee;


  constructor(private ApiService: AttendanceService, private router: Router, private api: EmployeeService) { }

  ngOnInit(): void {
    this.read(); //for getall

  }

  read() {
    this.ApiService.getall().subscribe({
      next: (x) => {
        this.attendance = x.data;
        console.log(x)

      },
      error: (response) => {
        console.log(response);
      }
    }

    );
  }

  addForm() {
    if (this.attendance.length) {
      this.new = {};
    }
    this.attendanceForm = true;
  }

  save(user: IAttendence) {

    this.ApiService.addAttendence(user).subscribe({
      next: (res) => {
        console.log(res)
        alert('attendance added');
      }
    });
    
  }
}
