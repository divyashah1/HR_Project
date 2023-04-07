import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { IEmployee } from './iemployee';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  readonly ApiUrl = " https://localhost:7282/api/Employee"

  constructor(private HttpClient:HttpClient) { }

  getall(): Observable<IEmployee[]> {
    return this.HttpClient.get<IEmployee[]>(this.ApiUrl);
  }

  GetSpecificEmp(id: Number) : Observable<IEmployee>{
    return this.HttpClient.get<IEmployee>(this.ApiUrl+id);
  }

  addEmployees(addEmployees :IEmployee) : Observable<IEmployee>{
    
    return this.HttpClient.post<IEmployee>(this.ApiUrl,addEmployees);
 
  }
  updateEmployee(update :IEmployee) :  Observable<IEmployee>{
    return this.HttpClient.put<IEmployee>(this.ApiUrl,update);
 
  }

 // Delete
}
