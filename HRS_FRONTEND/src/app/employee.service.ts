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

  getall(): Observable<any> {
    return this.HttpClient.get<any>(this.ApiUrl);
  }

  // GetSpecificEmp(id: any) : Observable<IEmployee>{
  //   return this.HttpClient.get<IEmployee>(this.ApiUrl+"/"+id);
  // }

  GetSpecificEmp(id: string) : Observable<any>{
    return this.HttpClient.get<any>(this.ApiUrl+"/"+id);
  }

  addEmployees(addEmployees :IEmployee) : Observable<IEmployee>{
    
    return this.HttpClient.post<IEmployee>(this.ApiUrl,addEmployees);
 
  }
  // updateEmployee(update :IEmployee) :  Observable<IEmployee>{
  //   return this.HttpClient.put<IEmployee>(this.ApiUrl+"/",update);
 
  // }

  updateEmployee(id:any,update :IEmployee) :  Observable<IEmployee>{
   // console.log(id,update)
    return this.HttpClient.put<IEmployee>(this.ApiUrl+"/"+id,update);
 
  }

  deleteEmployee(id: string): Observable<IEmployee> {
    return this.HttpClient.delete<IEmployee>(this.ApiUrl + '/api/employees/' + id);
  }
}
