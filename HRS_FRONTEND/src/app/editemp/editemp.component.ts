import { Component } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { IEmployee } from '../iemployee';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeeService } from '../employee.service';
import { parse } from 'date-fns';
@Component({
  selector: 'app-editemp',
  templateUrl: './editemp.component.html',
  styleUrls: ['./editemp.component.css']
})
export class EditempComponent {
  addEmpForm!: FormGroup;
  id: any;
  //emp!: IEmployee;
  addEmployeeRequest: IEmployee = {
    //id: '',
    name: '',
    address: '',
  
    mobile : 0,
    dep_Id : 0,
    designation_Id : 0,
    manager_Id : 0,

  };

  //id: any;


  constructor(private route: ActivatedRoute,
    private router: Router,
    private ApiService: EmployeeService,
    private formBuilder: FormBuilder
  ) { }

  ngOnInit(): void {
    // this.id = Number(this.route.snapshot.paramMap.get('id'));

    this.addEmpForm = this.formBuilder.group({
      id: ['response.id'],
      name: ['', [Validators.required]],
      address: ['', [Validators.required]],
    
      mobile: ['', [Validators.required]],
      dep_Id: ['', [Validators.required]],
      designation_Id: ['', [Validators.required]],
      manager_Id: ['', [Validators.required]]
    })

    
     this.id = String(this.route.snapshot.paramMap.get('id'));     // getting id from url
    this.ApiService.GetSpecificEmp(this.id).subscribe(res => {
      this.addEmployeeRequest = res;
    })
 
  }

  
  UpdateEmployee() {
    var req: IEmployee = {
    //id: this.addEmpForm.value.id,
      name: this.addEmpForm.value.name,
      address: this.addEmpForm.value.address,
  
      mobile: this.addEmpForm.value.mobile,
      dep_Id: this.addEmpForm.value.dep_Id,
      designation_Id: this.addEmpForm.value.designation_Id,
      manager_Id: this.addEmpForm.value.manager_Id
    };
   console.log(req);
  // console.log(this.id);
    // this.ApiService.updateEmployee(this.id,req).subscribe((x) => {
    //   this.router.navigate(['app-employee']);
    // })
    this.ApiService.updateEmployee(this.id,req);
    this.router.navigate(['app-employee']);
  }

}


