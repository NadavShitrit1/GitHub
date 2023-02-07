import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IUser } from '../models/User';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  user?: IUser;
  userAuth?: void;

  constructor( public accountService: AccountService,user: AccountService) { }

  ngOnInit() {
  }

  ngOnChanges(){

  }

  loggedIn(){
    this.accountService.isAuthenticated;
  }

  onLogout(){
    this.accountService.logout();
  }

  getUserName(){
  }

}
