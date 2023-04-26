import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms'
import { IEmployee } from '../iemployee';
import { Router, RouterModule } from '@angular/router';
import { EmployeeService } from '../employee.service';
@Component({
  selector: 'app-addemp',
  templateUrl: './addemp.component.html',
  styleUrls: ['./addemp.component.css']
})
export class AddempComponent implements OnInit {

  addEmpForm!: FormGroup;
  addEmployeeRequest!: IEmployee;

  constructor(private router: Router, private formBuilder: FormBuilder, private ApiService: EmployeeService) { }

  ngOnInit(): void {

    this.addEmpForm = this.formBuilder.group({
      name: ['', [Validators.required]],
      address: ['', [Validators.required]],

      mobile: ['', [Validators.required]],
      dep_Id: ['', [Validators.required]],
      designation_Id: ['', [Validators.required]],
      createdBy: ['', [Validators.required]],
      createdon: ['', [Validators.required]],
      updatedBy: ['', [Validators.required]],
      updatedOn: ['', [Validators.required]]
    })
  }

  AddEmployee() {
    this.addEmployeeRequest = {

      name: this.addEmpForm.value.name,
      address: this.addEmpForm.value.address,

      mobile: this.addEmpForm.value.mobile,
      dep_Id: this.addEmpForm.value.dep_Id,
      designation_Id: this.addEmpForm.value.designation_Id,
      createdBy: this.addEmpForm.value.createdBy,
      createdon: this.addEmpForm.value.createdon,
      updatedBy:this.addEmpForm.value.updatedBy,
      updatedOn: this.addEmpForm.value.updatedOn

    };

    this.ApiService.addEmployees(this.addEmployeeRequest).subscribe(() => {
      alert('emp added');
      this.router.navigate(['/app-employee'])
    })
  }


}
