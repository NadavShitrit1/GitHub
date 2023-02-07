import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable, shareReplay } from 'rxjs';
import { IMyRepo } from 'src/app/models/Repository';
import { AccountService } from 'src/app/services/account.service';
import { RepositoryService } from 'src/app/services/repository.service';

@Component({
  selector: 'app-repository-gallery',
  templateUrl: './repository-gallery.component.html',
  styleUrls: ['./repository-gallery.component.css']
})
export class RepositoryGalleryComponent implements OnInit {
  repoForm: FormGroup;

  repositoryToSearch = '';
  authRepositoryToSearch ='';

  repositories$: Observable<IMyRepo[]> = new Observable<IMyRepo[]>();

  repositoriesAuth$: Observable<IMyRepo[]> = new Observable<IMyRepo[]>();

  constructor(private reposService: RepositoryService,private fb: FormBuilder,private accountService:AccountService) {
    this.repoForm = this.fb.group({
      searchInput: [null,[Validators.required]]
    })
  }

  onSubmit(){
    if(this.accountService.isAuthenticated)
      this.getGitHubSearch(this.repoForm.value.searchInput)
    else{
      this.getGitHubSearchNoAuth(this.repoForm.value.searchInput)
    }

  }

  ngOnInit() {
  }

  getGitHubSearchNoAuth(repoToSearch:string)
  {
    this.repositories$ = this.reposService.GitHubSearchNoAuth(repoToSearch);
  }

  getGitHubSearch(repoToSearch:string)
  {
    this.repositoriesAuth$ = this.reposService.GitHubSearch(repoToSearch).pipe(shareReplay(1));
  }

}
