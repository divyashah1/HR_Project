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

  addEmpForm!:FormGroup;
  addEmployeeRequest!:IEmployee;
//  empobj : IEmployee = new IEmployee();
  //emp : any;

  // addEmployeeRequest: IEmployee = {
  //   id: '',
  //   name: '',
  //   address: '',
  //   dob : '',
  //   mobile : 0,
  //   dep_Id : 0,
  //   designation_Id : 0,
  //   manager_Id : 0,
    
  // };
  constructor(private router: Router,private formBuilder : FormBuilder, private  ApiService: EmployeeService) { }

  ngOnInit(): void {

    this.addEmpForm = this.formBuilder.group({
      name: ['', [Validators.required]],
      address: ['', [Validators.required]],
      dob: ['', [Validators.required]],
      mobile: ['', [Validators.required]],
      dep_Id: ['', [Validators.required]],
      designation_Id: ['', [Validators.required]],
      manager_Id: ['', [Validators.required]]
    })
  }

  // save(addEmpForm : IEmployee) {
  //   this.ApiService.addEmployees(addEmpForm).subscribe({
  //     next:(x) => {
  //       alert('emp added');
  //       this.router.navigate(['/app-employee']);
  //     },
  //     error: (response) => {
  //       console.log(response);
  //     }
  //   });
  // }

  AddEmployee(){
    this.addEmployeeRequest={
      
      name:this.addEmpForm.value.name,
      address:this.addEmpForm.value.address,
      dob:'2023-04-06T10:19:57.048Z',//
      //dob:this.addEmpForm.value.dob,//2023-04-06T10:19:57.048Zs
      mobile:this.addEmpForm.value.mobile,
      dep_Id:this.addEmpForm.value.dep_Id,
      designation_Id:this.addEmpForm.value.designation_Id,
      manager_Id:this.addEmpForm.value.manager_Id

    };
    
    // this.ApiService.addEmployees(this.addEmployeeRequest)
    // .subscribe({
    //   next:(res)=>{
    //     console.log(res)
    //    // alert('emp added');
    //     this.router.navigate(['/app-employee'])
    //   //}
    //   }
    // });
  this.ApiService.addEmployees(this.addEmployeeRequest).subscribe(()=>{

  })
  }


}
