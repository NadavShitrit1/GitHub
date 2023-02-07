import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder,ReactiveFormsModule,AbstractControl } from '@angular/forms';
import { IRegister, IUser } from 'src/app/models/User';
import { AccountService } from 'src/app/services/account.service';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registrationForm: FormGroup;
  user: IRegister | undefined;
  userSubmitted: boolean =false;

  constructor(private fb: FormBuilder,private accountService:AccountService) {

    this.registrationForm = new FormGroup({
      userName: new FormControl(null,[Validators.required]),
      password: new FormControl(null, [Validators.required, Validators.minLength(6)]),
    } );  }

  ngOnInit() {
  }


  onSubmit() {
    if (this.registrationForm.valid) {
      this.userSubmitted = true
      this.accountService.register(this.registrationForm.value).subscribe()
      this.registrationForm.reset();

    this.userSubmitted = false;
    }
  }

  get userName() { return this.registrationForm.get('userName') as FormControl; }
  get password() { return this.registrationForm.get('password'); }
}
