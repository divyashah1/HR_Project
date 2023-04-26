import { Component } from '@angular/core';
import { IManager } from '../imanager';
import { ManagerService } from '../manager.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-manager',
  templateUrl: './manager.component.html',
  styleUrls: ['./manager.component.css']
})
export class ManagerComponent {
  manager;
  column: string[] = [];
  managerForm: boolean;
  new : any ={};

  constructor(private ApiService: ManagerService, private router: Router) { }

  ngOnInit(): void {

  
    this.ApiService.getall().subscribe({
      next: (x) => {
        this.manager = x.data;
        this.column = Object.keys(x.data[0]);
        console.log(x);
      },
      error: (response) => {
        console.log(response);
      }
    });


  }

  addForm() {
    if (this.manager.length) {
      this.new = {};
    }
    this.managerForm = true;
  }

  save(user: IManager) {
    console.log(user)
    //  this.ApiService.addSalary(user);
    this.ApiService.add(user).subscribe({
      next: (res) => {
        console.log(res)
        alert('New Manager added');


      }
    });
  }

}

