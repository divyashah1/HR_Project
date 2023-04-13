import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
import { ISalary } from './isalary';
@Injectable({
  providedIn: 'root'
})
export class SalaryService {

  readonly ApiUrl = "https://localhost:7282/api/Salary"

  constructor(private HttpClient: HttpClient) { }

  getall(): Observable<ISalary[]> {
    return this.HttpClient.get<ISalary[]>(this.ApiUrl);
  }

  addSalary(salary: ISalary): Observable<ISalary> {

    return this.HttpClient.post<ISalary>(this.ApiUrl, salary);

  }

  update(update: ISalary): Observable<ISalary> {
    return this.HttpClient.put<ISalary>(this.ApiUrl + "/", update);

  }

  deleteSalary(id: number){
    return this.HttpClient.delete(this.ApiUrl + '/Salary/' + id);
  }
}
