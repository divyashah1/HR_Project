import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeComponent } from './employee/employee.component';
import { AddempComponent } from './addemp/addemp.component';
import { EditempComponent } from './editemp/editemp.component';
import { DesignationComponent } from './designation/designation.component';
import { DepartmentComponent } from './department/department.component';

const routes: Routes = [
  { path: '', redirectTo: 'app-employee', pathMatch: 'full' },
  { path: 'app-employee', component: EmployeeComponent },
  { path: 'app-employee/:id', component: EmployeeComponent },
  
  { path: 'addemp', component: AddempComponent },
  // { path: 'app-employee/editemp/:id', component: EditempComponent }
  { path: 'editemp/:id', component: EditempComponent },
  { path: 'app-designation', component: DesignationComponent },
  { path: 'add-department', component: DepartmentComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
