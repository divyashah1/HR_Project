import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { Observable } from 'rxjs';
import { ILeave } from './ileave';

@Injectable({
  providedIn: 'root'
})
export class LeaveService {

  readonly ApiUrl = "https://localhost:7282/api/Leave"

  
  constructor(private HttpClient:HttpClient) { }

  getall(): Observable<ILeave[]> {
    return this.HttpClient.get<ILeave[]>(this.ApiUrl);
  }

  add(addleave :ILeave) : Observable<ILeave>{
    
    return this.HttpClient.post<ILeave>(this.ApiUrl,addleave);
 
  }
  
}
