import { ChangeDetectionStrategy, Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { IMyRepo } from 'src/app/models/Repository';
import { RepositoryService } from 'src/app/services/repository.service';

@Component({
  selector: 'app-repository-item',
  templateUrl: './repository-item.component.html',
  styleUrls: ['./repository-item.component.css'],
})
export class RepositoryItemComponent implements OnInit {
  @Input() repository: IMyRepo | undefined
  @Input() fromBookmarks = false
  @Output() repoEmmiter = new EventEmitter<string>();
  isAdded: boolean = false;

  constructor(private reposService: RepositoryService) { }

  ngOnInit(): void {
  }

  addBookmark(){
    if(this.repository)
    this.reposService.bookmarkRepo(this.repository).subscribe();
    this.isAdded = true;
  }

  unbookmark(){
    if(this.repository)
      this.reposService.Unbookmark(this.repository).pipe().subscribe();
      this.repoEmmiter.emit(this.repository?.name);
  }
}
