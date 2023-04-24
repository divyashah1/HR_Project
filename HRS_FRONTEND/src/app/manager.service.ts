import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
import { IManager } from './imanager';
@Injectable({
  providedIn: 'root'
})
export class ManagerService {
  readonly ApiUrl = "https://localhost:7282/api/Manager"

  constructor(private HttpClient: HttpClient) { }

  getall(): Observable<any> {
    return this.HttpClient.get<any>(this.ApiUrl);
  }

  add(manager: IManager): Observable<IManager> {

    return this.HttpClient.post<IManager>(this.ApiUrl, manager);

  }

  getByleaveId(id: number): Observable<any>{
    return this.HttpClient.get<any>(this.ApiUrl+"/api/Manager"+id+"/Leave");
  }

 
}
