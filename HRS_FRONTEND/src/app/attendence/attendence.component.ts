import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AttendanceService } from '../attendance.service';
import { IAttendence } from '../iattendence';

@Component({
  selector: 'app-attendence',
  templateUrl: './attendence.component.html',
  styleUrls: ['./attendence.component.css']
})
export class AttendenceComponent {
  attendance;
  attendanceForm: boolean;
  new: any = {};


  constructor(private ApiService: AttendanceService, private router: Router) { }

  ngOnInit(): void {
    this.read(); //for getall

  }

  read() {
    this.ApiService.getall().subscribe(
      data => {
        this.attendance = data;
        console.log(data)
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
    // this.ApiService.addAttendence(user).subscribe(()=>{

    // })
    //console.log(user)
    this.ApiService.addAttendence(user).subscribe({
      next: (res) => {
        console.log(res)
        alert('attendance added');


      }
    });
  }
}
