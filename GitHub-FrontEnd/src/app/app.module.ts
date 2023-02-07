import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { Routes,RouterModule } from '@angular/router';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { LoginComponent } from './components/account/login/login.component';
import { RegisterComponent } from './components/account/register/register.component';
import { BookmarksComponent } from './components/bookmarks/bookmarks.component';
import { AccountService } from './services/account.service';
import { RepositoryItemComponent } from './components/repository-item/repository-item.component';
import { RepositoryGalleryComponent } from './components/repository-gallery/repository-gallery.component';
import { AuthGuard } from 'src/guards/auth.guard';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { JwtInterceptor } from './auth.interceptor';

const appRoutes:Routes =[
  { path: '', redirectTo:"browse",pathMatch: 'full' },
  { path: 'browse',component: RepositoryGalleryComponent, canActivate: [AuthGuard] },
  { path: 'browseNoAuth',component: RepositoryGalleryComponent },
  { path: 'bookmarks',canActivate: [AuthGuard],component: BookmarksComponent},

  { path: 'login', component: LoginComponent  },
  { path: 'register', component: RegisterComponent  },

  { path: '**', component: NotFoundComponent  },
]

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    LoginComponent,
    RegisterComponent,
    BookmarksComponent,
    RepositoryItemComponent,
    RepositoryGalleryComponent,
   ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [ {provide: HTTP_INTERCEPTORS,useClass: JwtInterceptor, multi: true}],
  bootstrap: [AppComponent]
})
export class AppModule { }
