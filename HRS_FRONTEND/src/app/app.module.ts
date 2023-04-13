import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EmployeeComponent } from './employee/employee.component';
import { DepartmentComponent } from './department/department.component';
import { DesignationComponent } from './designation/designation.component';
import { LeaveComponent } from './leave/leave.component';
import { SalaryComponent } from './salary/salary.component';
import { AttendenceComponent } from './attendence/attendence.component';
import { RejectComponent } from './approval/reject/reject.component';

import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddempComponent } from './addemp/addemp.component';
import { EditempComponent } from './editemp/editemp.component';
import { AddleaveComponent } from './leave/addleave/addleave.component';
@NgModule({
  declarations: [
    AppComponent,
    EmployeeComponent,
    DepartmentComponent,
    DesignationComponent,
    LeaveComponent,
    SalaryComponent,
    AttendenceComponent,
    RejectComponent,
    AddempComponent,
    EditempComponent,
    AddleaveComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
