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

  edit!: FormGroup;
  //emp!: IEmployee;
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

  emp: any;
  

  constructor(private route: ActivatedRoute,
      private router: Router,
      private  ApiService: EmployeeService,
      private formBuilder: FormBuilder
    ) { }

  ngOnInit(): void {
    this.edit = this.formBuilder.group({
      id:['', [Validators.required]],
      name: ['', [Validators.required]],
      address: ['', [Validators.required]],
      dob: ['', [Validators.required]],
      mobile: ['', [Validators.required]],
      dep_Id: ['', [Validators.required]],
      designation_Id: ['', [Validators.required]],
      manager_Id: ['', [Validators.required]]
    })

  //   const id = Number(this.route.snapshot.paramMap.get('id'));
  //   if(id!=null){
  //     this.ApiService.GetSpecificEmp(id)
  //       .subscribe({
  //         next: (x) => {
  //           this.emp = x;
  //         }
  //       });
  //   }
  // }

  // updateEmployee() {
  //   this.ApiService.UpdateEmployee( this.emp).subscribe((x)=> {
  //     this.router.navigate(['employee']);
  //   })
  }
}
