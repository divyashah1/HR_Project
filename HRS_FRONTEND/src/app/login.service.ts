import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { Observable } from 'rxjs';
import { Ilogin } from './ilogin';


@Injectable({
  providedIn: 'root'
})
export class LoginService {
  readonly ApiUrl = "https://localhost:7282/api/Login"

 
  constructor(private HttpClient:HttpClient) { }

  getall(): Observable<any> {
    return this.HttpClient.get<any>(this.ApiUrl);
  }

  add(addleave :Ilogin) : Observable<Ilogin>{
    
    return this.HttpClient.post<Ilogin>(this.ApiUrl,addleave);
 
  }
}
