import { Component } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { IEmployee } from '../iemployee';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeeService } from '../employee.service';

@Component({
  selector: 'app-editemp',
  templateUrl: './editemp.component.html',
  styleUrls: ['./editemp.component.css']
})
export class EditempComponent {
  editEmpForm!: FormGroup;

  emp!: IEmployee;
  // emp: IEmployee = {
  //   id: ,
  //   name: '',
  //   address: '',
  //   dob : '',
  //   mobile : 0,
  //   dep_Id : 0,
  //   designation_Id : 0,
  //   manager_Id : 0,

  // };

  id: any;


  constructor(private route: ActivatedRoute,
    private router: Router,
    private ApiService: EmployeeService,
    private formBuilder: FormBuilder
  ) { }

  ngOnInit(): void {
    // this.id = Number(this.route.snapshot.paramMap.get('id'));

    this.editEmpForm = this.formBuilder.group({
      id: ['response.id'],
      name: ['', [Validators.required]],
      address: ['', [Validators.required]],
      dob: ['', [Validators.required]],
      mobile: ['', [Validators.required]],
      dep_Id: ['', [Validators.required]],
      designation_Id: ['', [Validators.required]],
      manager_Id: ['', [Validators.required]]
    })

    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.ApiService.GetSpecificEmp(id).subscribe(res => {
      this.emp = res;
    })
    // if (id != null) {
    //   this.ApiService.GetSpecificEmp(id)
    //     .subscribe({
    //       next: (x) => {
    //         this.emp = x;
    //         this.editEmpForm = this.formBuilder.group({
    //           //id: [this.emp.id, [Validators.required]],
    //           name: [this.emp.name, [Validators.required]],
    //           address: [this.emp.address, [Validators.required]],
    //           dob: [this.emp.dob,  [Validators.required]],
    //           mobile: [this.emp.mobile, [Validators.required]],
    //           dep_Id: [this.emp.dep_Id,  [Validators.required]],
    //           designation_Id: [this.emp.designation_Id, [Validators.required]],
    //           manager_Id: [this.emp.manager_Id, [Validators.required]]
    //         });
    //       },
    //       error:(res)=>{
    //         console.log(res);
    //       }
    //     });
    // }
  }

  // UpdateEmployee(updateEmployee: IEmployee) {
  //   this.ApiService.updateEmployee(updateEmployee).subscribe((x) => {
  //     this.router.navigate(['app-employee']);
  //   })
  // }
  UpdateEmployee() {
    var req: IEmployee = {
      name: this.emp.name,
      address: this.emp.address,
      dob: this.emp.dob,
      mobile: this.emp.mobile,
      dep_Id: this.emp.dep_Id,
      designation_Id: this.emp.designation_Id,
      manager_Id: this.emp.manager_Id
    };
    let id = this.emp.
    this.ApiService.updateEmployee(updateEmployee).subscribe((x) => {
      this.router.navigate(['app-employee']);
    })
  }
}
