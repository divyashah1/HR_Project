import { Component } from '@angular/core';

import { Ilogin } from '../ilogin';
import { FormBuilder, FormGroup, Validators } from '@angular/forms'; // import forms library
import { Router } from '@angular/router';
import { LoginService } from '../login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  // loginForm!: FormGroup;
  // login : Ilogin[] =[];
  loginObj : any ={
    user_Name: '',
    password: ''
  };

  constructor(private ApiService: LoginService, private fb: FormBuilder, private router: Router) { } // fb - form builder

  ngOnInit(): void { // method
   
    // this.loginForm = this.fb.group({
    //   userName: ['', [Validators.required]],
    //   password: ['', [Validators.required]]
    // })
  }

  OnLogin() {
   
    this.ApiService.login(this.loginObj).subscribe((res:any) => {
  
   //   console.log('res',res)
      localStorage.setItem('token',res.token);
      this.router.navigate(['/app-employee'])
    })
  }
 
   
}

