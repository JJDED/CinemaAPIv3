import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Subscription } from 'rxjs';
import { CommonModule } from '@angular/common';
import { UiService } from '../../service/ui.service';
import { MovieService } from '../../service/movie.service';
import { MovieDetailed, MovieUpdate, MovieCreate, MovieSimple } from '../../models/movie';

@Component({
  selector: 'app-update-movie',
  imports: [FormsModule, CommonModule],
  templateUrl: './update-movie.component.html',
  styleUrl: './update-movie.component.css'
})
export class UpdateMovieComponent {
  @Input() movie!: MovieDetailed;
  @Output() onUpdateMovie: EventEmitter<MovieUpdate> = new EventEmitter();
  
  title!: string;
  durationMinutes!: number;
  releaseYear!: number;
  showAddMovie!: boolean;
  subscription!: Subscription;

  constructor(private uiService: UiService, private movieService: MovieService) { 
    this.subscription = this.uiService
      .onToggle()
      .subscribe((value) => (this.showAddMovie = value));
  }

  ngOnInit(): void {
    if (this.movie) {
      this.title = this.movie.title;
      this.durationMinutes = this.movie.durationMinutes;
      this.releaseYear = this.movie.releaseYear;
    }
  }
  
  onSubmit() {
    if (!this.title) {
      alert('Please add a movie');
      return;
    }
    if (!this.durationMinutes) {
      alert('Please add length of movie in minutes');
      return;
    }
    if (!this.releaseYear) {
      alert('Please add a release year');
      return;
    }
  
    const updatedMovie: MovieUpdate = {
      title: this.title,
      description: '', // Add a description property
      durationMinutes: this.durationMinutes,
      releaseYear: this.releaseYear
    }
  
    this.onUpdateMovie.emit(updatedMovie); // Emit the updated movie object
    this.title = '';
    this.durationMinutes = 0;
    this.releaseYear = 0;     
  }
}

