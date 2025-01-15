import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Subscription } from 'rxjs';
import { CommonModule } from '@angular/common';
import { UiService } from '../../service/ui.service';
import { MovieService } from '../../service/movie.service';

@Component({
  selector: 'app-add-movie',
  imports: [FormsModule, CommonModule],
  templateUrl: './add-movie.component.html',
  styleUrl: './add-movie.component.css'
})
export class AddMovieComponent {
  @Output() onAddMovie: EventEmitter<any> = new EventEmitter();
  
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
  
    const newMovie = {
      title: this.title,
      description: '', // Add a description property
      durationMinutes: this.durationMinutes,
      releaseYear: this.releaseYear
    }
  
    this.onAddMovie.emit(newMovie); // Emit the new movie object
    this.title = '';
    this.durationMinutes = 0;
    this.releaseYear = 0;     
    };
  }

