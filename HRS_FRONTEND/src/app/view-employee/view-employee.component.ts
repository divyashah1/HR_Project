import { Component } from '@angular/core';
import { IEmployee } from '../iemployee';
import { EmployeeService } from '../employee.service';
import { ActivatedRoute, Router } from '@angular/router';
import { DesignationService } from '../designation.service';


@Component({
  selector: 'app-view-employee',
  templateUrl: './view-employee.component.html',
  styleUrls: ['./view-employee.component.css']
})
export class ViewEmployeeComponent {
  employee: IEmployee;
  name!: string;
  mobile!:number;
  id!:any;
  Address!:any;
  designation_Name!: any;
  designation;
  constructor(private api : DesignationService,private ApiService: EmployeeService, private activatedRoute: ActivatedRoute,private router: Router) { }
  ngOnInit(): void {
    // this.ApiService.getall().subscribe({
    //   next: (x) => {
    //     this.employee = x.data;
        

       
    //     //this.total = x.total;
    //     console.log(x);
    //   },
    //   error: (response) => {
    //     console.log(response);
    //   }
    // });

     this.id = this.activatedRoute.snapshot.params['id'];
    
      this.ApiService.GetSpecificEmp(this.id).subscribe({
        next: (x) => {
          this.employee=x.data;
          console.log(this.employee)
          this.name = this.employee.name
          this.mobile = this.employee.mobile
          this.Address = this.employee.address
        }
      })
      
      this.api.GetSpecific(this.id).subscribe({
        next: (x) => {
          this.designation=x;
          this.designation_Name = this.designation.designation_Name
          console.log(this.designation_Name)
        }
      })
    
  }
}
