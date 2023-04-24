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
  loginForm!: FormGroup;
//login : Ilogin[] =[];
//   logedInUser: any;  
// login;

  constructor(private ApiService: LoginService, private fb: FormBuilder, private router: Router) { } // fb - form builder

  ngOnInit(): void { // method
    //this.ApiService.GetSpecific
    //this.login = JSON.parse(localStorage.getItem('regUserLocalStorage')!);
    this.loginForm = this.fb.group({
      userName: ['', [Validators.required]],
      password: ['', [Validators.required]]
    })
  }

  check() {
    if(this.loginForm.valid)
    {
      this.ApiService.login(this.loginForm.value).subscribe(result => {
        if(result.status){
          console.log(result)
          alert(result.Message);
        }else {
          alert(result.Message);
        }
      });
    }
   
    // this.ApiService.add(this.login).subscribe(res => {
    //   //if(data)
    //   alert('sign')
    // })
    // let userName = this.loginForm.value.userName;
    // let password = this.loginForm.value.password;
    // for (let i = 0; i < this.login.length; i++) {
    //   // to verify user email and password
    //   if (this.login[i].userName == userName && this.login[i].password == password) {
    //     // alert("Login is successful");
    //     // logedInUser objects object
    //     this.logedInUser = {
    //       //logedInUserName: this.login[i].fullName,
    //       logedInUserEmail: this.login[i].userName,
    //       logedInUserId: this.login[i].userId
    //     }
    //   //  localStorage.setItem('logedInUser', JSON.stringify(this.logedInUser));
    //     this.router.navigate(['/app-employee']); // redirect
    //     return;
    //   }
    // }
  }
}


// this.ApiService.getall().subscribe({
//   next: (x) => {
//     this.employee = x.data;
//     this.column = Object.keys(x.data[0]);
   
//     this.pagingConfig.totalItems = x.length;
//     //this.total = x.total;
//     console.log(x);
//   },
//   error: (response) => {
//     console.log(response);
//   }
// });