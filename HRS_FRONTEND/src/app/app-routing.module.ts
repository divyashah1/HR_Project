import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeComponent } from './employee/employee.component';
import { AddempComponent } from './addemp/addemp.component';
import { EditempComponent } from './editemp/editemp.component';

const routes: Routes = [
  { path: '', redirectTo: 'app-employee', pathMatch: 'full' },
  { path: 'app-employee', component: EmployeeComponent },
  { path: 'app-employee/:id', component: EmployeeComponent },
  
  { path: 'addemp', component: AddempComponent },
  // { path: 'app-employee/editemp/:id', component: EditempComponent }
  { path: 'editemp', component: EditempComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
