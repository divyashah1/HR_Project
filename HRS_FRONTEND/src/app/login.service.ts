import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { BehaviorSubject, Observable } from 'rxjs';

import { Ilogin } from './ilogin';


@Injectable({
  providedIn: 'root'
})
export class LoginService {
 // token: string;
  readonly ApiUrl = "https://localhost:7282/api/Login"
  //  private _isloggedIn$ = new BehaviorSubject<boolean>(false);
  //  _isloggedIn$ = this._isloggedIn.asObservable();


  constructor(private HttpClient: HttpClient) {

    // const token = localStorage.getItem('profanis_auth');
    // this._isloggedIn.next(!!token);
  }

  // getall(): Observable<any> {
  //   return this.HttpClient.get<any>(this.ApiUrl);
  // }

  // login(addleave: Ilogin) {

  // return this.HttpClient.post(this.ApiUrl, addleave).subscribe((result : any) => {
  //   localStorage.setItem("token",result);
  // });





  login(addleave): Observable<any> {
   
    return this.HttpClient.post(this.ApiUrl, addleave);

  }

  GetSpecific(id: number): Observable<any> {
    return this.HttpClient.get<any>(this.ApiUrl + "/" + id);
  }
}
