import { Component } from '@angular/core';
import { SalaryService } from '../salary.service';
import { FormGroup } from '@angular/forms';
import { ISalary } from '../isalary';
import { Router } from '@angular/router';

@Component({
  selector: 'app-salary',
  templateUrl: './salary.component.html',
  styleUrls: ['./salary.component.css']
})
export class SalaryComponent {
  salary;
  id: any;
  salaryForm: boolean;
  editForm: boolean;
  edited: any = {}
  new: any = {};
employee;
  constructor(private ApiService: SalaryService, private router: Router) { }

  ngOnInit(): void {
    this.read(); //for getall

  }

  
  //getall

  read() {
    this.ApiService.getall().subscribe(
      data => {
        this.salary = data;
        console.log(data)
      }
    );
  }

  addForm() {
    if (this.salary.length) {
      this.new = {};
    }
    this.salaryForm = true;
  }

  save(user: ISalary) {
    console.log(user)
    //  this.ApiService.addSalary(user);
    this.ApiService.addSalary(user).subscribe({
      next: (res) => {
        console.log(res)
        alert('salary added');


      }
    });
  }

  edit(user: ISalary) {
    if(!user) 
    {
      this.salaryForm = false;
      return;
      
    }
    this.editForm=true;
    this.edited=user;
    // this.ApiService.update(this.edit);
    // this.editForm = false;
    // this.edit = {}
  }


  delete(id: number) {
  this.salary.splice(this.salary.indexOf(id), 1);
    // this.ApiService.deleteSalary(id).subscribe(x => {
    //   console.log(x)
    //  
    //  // this.router.navigate(['app-salary']);
    // });
  }

  update() {
    this.ApiService.update(this.edited);
    this.editForm=false;
    this.edited={};
  }

}

