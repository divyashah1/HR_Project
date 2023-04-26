import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ILeave } from 'src/app/ileave';
import { Router, RouterModule } from '@angular/router';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms'
import { LeaveService } from 'src/app/leave.service';
import { EmployeeService } from 'src/app/employee.service';
import { ManagerService } from 'src/app/manager.service';



@Component({
  selector: 'app-addleave',
  templateUrl: './addleave.component.html',
  styleUrls: ['./addleave.component.css']
})
export class AddleaveComponent {
  employee;
  manager;
  addEmpForm!: FormGroup;
  addEmployeeRequest!: ILeave;
  constructor(private router: Router, private formBuilder: FormBuilder, private ApiService: LeaveService , private api: EmployeeService, private webapi : ManagerService) { }

  ngOnInit(): void {

    this.addEmpForm = this.formBuilder.group({
      leave_Type: ['', [Validators.required]],
      emp_ID: ['', [Validators.required]],
      leave_From: ['', [Validators.required]],
      leave_To: ['', [Validators.required]],
      manager_Id: ['', [Validators.required]],
      isAccepted: ['', [Validators.required]],
      Applied_Date: ['', [Validators.required]],
     // isActive:['', [Validators.required]]
    })

    this.api.getall().subscribe(res=>{this.employee=res.data})
    this.webapi.getall().subscribe(res=>this.manager=res.data)
  }


  Addleave() {
    this.addEmployeeRequest = {

      leave_Type: this.addEmpForm.value.leave_Type,
      emp_ID: this.addEmpForm.value.emp_ID,
    //  isActive: this.addEmpForm.value.isActive,
      leave_From: this.addEmpForm.value.leave_From,
      leave_To: this.addEmpForm.value.leave_To,
      manager_Id: this.addEmpForm.value.manager_Id,
      isAccepted: this.addEmpForm.value.isAccepted,
      Applied_Date: this.addEmpForm.value.Applied_Date

    };
  
    this.ApiService.add(this.addEmployeeRequest).subscribe((a)=>{
      console.log(a)
     alert("New Leave Added Succesfully")
     this.router.navigate(['/app-leave'])
    
    })

    

  }



}




