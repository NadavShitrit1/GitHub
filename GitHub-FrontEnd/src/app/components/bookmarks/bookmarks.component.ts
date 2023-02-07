import { Component, OnInit } from '@angular/core';
import { filter, map, Observable, of, shareReplay, switchMap } from 'rxjs';
import { IMyRepo } from 'src/app/models/Repository';
import { RepositoryService } from 'src/app/services/repository.service';

@Component({
  selector: 'app-bookmarks',
  templateUrl: './bookmarks.component.html',
  styleUrls: ['./bookmarks.component.css']
})
export class BookmarksComponent implements OnInit {
  bookmarks$:Observable<IMyRepo[]> = new Observable<IMyRepo[]>();

  constructor(private reposService: RepositoryService) { }

  ngOnInit() {
  }

  getBookmarks(){
    this.bookmarks$ = this.reposService.getBookmarks().pipe(shareReplay(1));
  }

  removeItem(repository: any) {
    this.bookmarks$ = this.bookmarks$.pipe(
      switchMap(repos => {
        return of(repos.filter(repo => repo.name !== repository));
      })
    );
  }
}
