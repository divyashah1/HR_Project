import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
import { IAttendence } from './iattendence';

@Injectable({
  providedIn: 'root'
})
export class AttendanceService {

  readonly ApiUrl = "https://localhost:7282/api/Attendance"

  constructor(private HttpClient: HttpClient) { }

  getall(): Observable<IAttendence[]> {
    return this.HttpClient.get<IAttendence[]>(this.ApiUrl);
  }

  // addSalary(salary: ISalary): Observable<ISalary> {

  //   return this.HttpClient.post<ISalary>(this.ApiUrl, salary);

  // }

  // update(update: ISalary): Observable<ISalary> {
  //   return this.HttpClient.put<ISalary>(this.ApiUrl + "/", update);

  // }

  // deleteSalary(id: number){
  //   return this.HttpClient.delete(this.ApiUrl + '/Salary/' + id);
  // }
}
