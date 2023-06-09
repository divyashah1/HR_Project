import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeComponent } from './employee/employee.component';
import { AddempComponent } from './addemp/addemp.component';
import { EditempComponent } from './editemp/editemp.component';
import { DesignationComponent } from './designation/designation.component';
import { DepartmentComponent } from './department/department.component';
import { SalaryComponent } from './salary/salary.component';
import { LeaveComponent } from './leave/leave.component';
import { AddleaveComponent } from './leave/addleave/addleave.component';
import { AttendenceComponent } from './attendence/attendence.component';
import { ManagerComponent } from './manager/manager.component';
import { LoginComponent } from './login/login.component';
import { LogoutComponent } from './logout/logout.component';

const routes: Routes = [
  { path: '', redirectTo: 'app-login', pathMatch: 'full' },
  { path: 'app-employee', component: EmployeeComponent },
  { path: 'app-employee/:id', component: EmployeeComponent },
  
  { path: 'addemp', component: AddempComponent },
  // { path: 'app-employee/editemp/:id', component: EditempComponent }
  { path: 'editemp/:id', component: EditempComponent },
  { path: 'app-designation', component: DesignationComponent },
  { path: 'add-department', component: DepartmentComponent},
  { path: 'app-salary', component: SalaryComponent},
  { path: 'app-leave', component: LeaveComponent},
  { path: 'addleave', component: AddleaveComponent},
  { path: 'app-attendance', component: AttendenceComponent},
  { path: 'app-manager', component: ManagerComponent},
  {path: 'app-login',component:LoginComponent},
{path:'app-logout',component:LogoutComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
