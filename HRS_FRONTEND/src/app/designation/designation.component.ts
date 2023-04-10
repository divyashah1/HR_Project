import { Component } from '@angular/core';
import { IDesignation } from '../idesignation';
import { DesignationService } from '../designation.service';

@Component({
  selector: 'app-designation',
  templateUrl: './designation.component.html',
  styleUrls: ['./designation.component.css']
})
export class DesignationComponent {

  designation;
  constructor(private ApiService: DesignationService) { }

  ngOnInit(): void {

    this.ApiService.getall().subscribe({
      next: (x) => {
        this.designation = x;
        console.log(x);
      },
      error: (response) => {
        console.log(response);
      }
    });

  }
}
