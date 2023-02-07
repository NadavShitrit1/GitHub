import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { ReplaySubject, Observable, tap } from 'rxjs';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs';
import { ILogin, IRegister, IUser } from '../models/User';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private currentUserSource = new ReplaySubject<IUser | null>(1);
  public currentUser$ = this.currentUserSource.asObservable();
  public isAuthenticated: boolean = false;


  constructor(private http: HttpClient,private router: Router ) {
     this.currentUserSource.next(null);
   }

   public register(user:IRegister): Observable<any> {
    return this.http.post<any>(
      'https://localhost:7220/api/Users/register',
        user ).pipe(
          map((user: IUser)=>{
            this.isAuthenticated = true;
            localStorage.setItem('token',user.token);
            this.currentUserSource.next(user);
            this.router.navigateByUrl('/');
          }
        )
      )
  }


  public login(user: ILogin) {
    return this.http.post<IUser>('https://localhost:7220/api/Users/login',  user )
    .pipe(
      tap((user: IUser) => {
        localStorage.setItem('token', user.token);
        this.currentUserSource.next(user);
        this.isAuthenticated = true;
      })
    );
  }

  logout(){
    localStorage.removeItem('token');
    this.isAuthenticated = false;
    this.currentUserSource.next(null);
    this.router.navigateByUrl('/login');
  }

}
