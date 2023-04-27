import { Injectable } from '@angular/core';
import { IEmployee } from './iemployee';
import {HttpClient} from '@angular/common/http'
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class DesignationService {

  readonly ApiUrl = "https://localhost:7282/api/Designation"

  constructor(private HttpClient:HttpClient) { }

  getall(): Observable<IEmployee[]> {
    return this.HttpClient.get<IEmployee[]>(this.ApiUrl);
  }

  GetSpecific(id: string) : Observable<any>{
    return this.HttpClient.get<any>(this.ApiUrl+"/"+id);
  }
  
}
