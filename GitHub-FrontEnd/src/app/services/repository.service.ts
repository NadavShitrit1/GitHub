import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { ReplaySubject, Observable, tap, map } from 'rxjs';
import { environment } from 'src/environments/environment';
import {  IMyRepo } from '../models/Repository';

@Injectable({
  providedIn: 'root'
})
export class RepositoryService {

constructor(private http: HttpClient,private router: Router) { }

  public GitHubSearchNoAuth(repoName: string): Observable<IMyRepo[]> {
    return this.http.get<IMyRepo[]>(`https://localhost:7220/api/GitHub/GitHubSearchNoAuth?repoName=${repoName}`);
  }

  public GitHubSearch(repoName: string): Observable<IMyRepo[]> {
    return this.http.get<IMyRepo[]>(`https://localhost:7220/api/GitHub/GitHubSearch?repoName=${repoName}`);
  }

  public bookmarkRepo(repoToCreate:IMyRepo){
    return this.http.post<IMyRepo>('https://localhost:7220/api/GitHub/BookmarkRepo',repoToCreate);
  }

  public Unbookmark(repoToRemove:IMyRepo){
    return this.http.delete(`https://localhost:7220/api/GitHub/Unbookmark/${repoToRemove.name}`);
  }


  public getBookmarks(){
    return this.http.get<IMyRepo[]>('https://localhost:7220/api/GitHub/GetUserRepos');
  }

}
