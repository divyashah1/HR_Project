import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ILeave } from 'src/app/ileave';
import { Router, RouterModule } from '@angular/router';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms'
import { LeaveService } from 'src/app/leave.service';



@Component({
  selector: 'app-addleave',
  templateUrl: './addleave.component.html',
  styleUrls: ['./addleave.component.css']
})
export class AddleaveComponent {
  addEmpForm!: FormGroup;
  addEmployeeRequest!: ILeave;
  constructor(private router: Router, private formBuilder: FormBuilder, private ApiService: LeaveService) { }

  ngOnInit(): void {

    this.addEmpForm = this.formBuilder.group({
      leave_Type: ['', [Validators.required]],
      emp_ID: ['', [Validators.required]],
      leave_From: ['', [Validators.required]],
      leave_To: ['', [Validators.required]],
      manager_Id: ['', [Validators.required]],
      approval_Id: ['', [Validators.required]]

    })
  }


  Addleave() {
    this.addEmployeeRequest = {

      leave_Type: this.addEmpForm.value.leave_Type,
      emp_ID: this.addEmpForm.value.emp_ID,

      leave_From: this.addEmpForm.value.leave_From,
      leave_To: this.addEmpForm.value.leave_To,
      manager_Id: this.addEmpForm.value.manager_Id,
      approval_Id: this.addEmpForm.value.approval_Id

    };
  
    this.ApiService.add(this.addEmployeeRequest).subscribe((a)=>{
     alert("New Leave Add Succesfully")
     this.router.navigate(['/app-leave'])
    
    })

  }



}


