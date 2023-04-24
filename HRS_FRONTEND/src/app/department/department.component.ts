import { Component } from '@angular/core';
import { DepartmentService } from '../department.service';

@Component({
  selector: 'app-department',
  templateUrl: './department.component.html',
  styleUrls: ['./department.component.css']
})
export class DepartmentComponent {
 department;

 constructor(private ApiService: DepartmentService) { }

  ngOnInit(): void {

    this.ApiService.getall().subscribe({
      next: (x) => {
        this.department = x;
        console.log(x);
      },
      error: (response) => {
        console.log(response);
      }
    });

  }

}
