import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder,ReactiveFormsModule,AbstractControl } from '@angular/forms';
import { Router } from '@angular/router';
import { IUser } from 'src/app/models/User';
import { AccountService } from 'src/app/services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  user!: IUser;
  userSubmitted: boolean =false;

  constructor(private fb: FormBuilder,private accountService:AccountService,private router: Router) {
    this.loginForm = new FormGroup({
      userName: new FormControl(null,[Validators.required]),
      password: new FormControl(null, [Validators.required, Validators.minLength(6)]),
    } );  }

  ngOnInit() {
    if(this.accountService.isAuthenticated)
      this.router.navigateByUrl("/browse")
  }

  onLogin() {
    this.userSubmitted = true
    this.accountService.login(this.loginForm.value).subscribe(()=>
      this.router.navigateByUrl('/')
    )

  }
  get userName() { return this.loginForm.get('userName') as FormControl; }
  get password() { return this.loginForm.get('password'); }

}
