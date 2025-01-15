import { Injectable } from '@angular/core';
import {Observable, Subject} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UiService {
  private showAddMovie: boolean = false;
  private subject = new Subject<any>();

  constructor() { }

  toggleAddMovie(): void {
    console.log('123');
    this.showAddMovie = !this.showAddMovie;
    this.subject.next(this.showAddMovie);
  }

  onToggle(): Observable<any> {
    return this.subject.asObservable();
  }
}
