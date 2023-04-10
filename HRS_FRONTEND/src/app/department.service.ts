import { Injectable } from '@angular/core';
import { IDepartment } from './idepartment';
import { Observable } from 'rxjs';
import {HttpClient} from '@angular/common/http'



@Injectable({
  providedIn: 'root'
})
export class DepartmentService {
  readonly ApiUrl = "https://localhost:7282/api/Department"
  constructor(private HttpClient:HttpClient) { }

  getall(): Observable<IDepartment[]> {
    return this.HttpClient.get<IDepartment[]>(this.ApiUrl);
  }



}
