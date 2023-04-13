import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { Observable } from 'rxjs';
import { ILeave } from './ileave';

@Injectable({
  providedIn: 'root'
})
export class LeaveService {

  readonly ApiUrl = "https://localhost:7282/api/Leave"

  // formDataEmployee: ILeave = {
  //  // id:0,
  //   leave_Type  : "",
  //   emp_ID : 0,
  //   leave_From: new Date(),  
  //   leave_To : new Date(),
  //    isActive : false,
  //     approval_Id: 0,
  // };
  constructor(private HttpClient:HttpClient) { }

  getall(): Observable<ILeave[]> {
    return this.HttpClient.get<ILeave[]>(this.ApiUrl);
  }

  add(addleave :ILeave) : Observable<ILeave>{
    
    return this.HttpClient.post<ILeave>(this.ApiUrl,addleave);
 
  }
  
}
