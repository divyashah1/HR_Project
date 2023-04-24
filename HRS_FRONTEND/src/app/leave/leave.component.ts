import { Component } from '@angular/core';
import { LeaveService } from '../leave.service';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-leave',
  templateUrl: './leave.component.html',
  styleUrls: ['./leave.component.css']
})
export class LeaveComponent {
  leave;
  editFormData!: FormGroup; // property form 
  constructor(private ApiService: LeaveService) { }

  ngOnInit(): void {
    this.read();

  }

 read(){
  this.ApiService.getall().subscribe(
    data => {
      this.leave = data;
      console.log(data)
    }
  );
 }

 onSubmit() {
  
 }
}
