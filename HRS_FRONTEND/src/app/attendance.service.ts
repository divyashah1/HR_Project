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

  addAttendence(attendance: IAttendence): Observable<IAttendence> {

    return this.HttpClient.post<IAttendence>(this.ApiUrl+"/AddAttendance", attendance);

  }

}
