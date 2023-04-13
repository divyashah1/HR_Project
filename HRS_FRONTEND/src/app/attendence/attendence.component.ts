import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AttendanceService } from '../attendance.service';

@Component({
  selector: 'app-attendence',
  templateUrl: './attendence.component.html',
  styleUrls: ['./attendence.component.css']
})
export class AttendenceComponent {
  attendance;
  constructor(private ApiService: AttendanceService, private router: Router) { }

  ngOnInit(): void {
    this.read(); //for getall

    // this.salary = this.
    // this.ApiService.getall().subscribe({
    //   next: (x) => {
    //     this.salary = x;
    //     console.log(x);
    //   },
    //   error: (response) => {
    //     console.log(response);
    //   }
    // });


  }

  read() {
    this.ApiService.getall().subscribe(
      data => {
        this.attendance = data;
        console.log(data)
      }
    );
  }
}
