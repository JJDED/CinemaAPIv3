import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { MovieDetailed, MovieUpdate } from '../../models/movie';
import { CommonModule } from '@angular/common';
import { ButtonComponent } from '../button/button.component';
import { faTimes, faPencil } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-movie-item',
  imports: [CommonModule, FontAwesomeModule, FormsModule, ButtonComponent],
  templateUrl: './movie-item.component.html',
  styleUrl: './movie-item.component.css'
})
export class MovieItemComponent implements OnInit {
  @Input() movie!: MovieDetailed;
  @Output() onDeleteMovie: EventEmitter<MovieDetailed> = new EventEmitter();
  @Output() onUpdateMovie: EventEmitter<MovieUpdate> = new EventEmitter();
  faTimes = faTimes;
  faPencil = faPencil;

  isEditing = false;
  editTitle!: string;
  editDurationMinutes!: number;
  editReleaseYear!: number;

  constructor() { 

  }

  ngOnInit(): void {
    this.editTitle = this.movie.title;
    this.editDurationMinutes = this.movie.durationMinutes;
    this.editReleaseYear = this.movie.releaseYear;    
  }

  onDelete(movie: MovieDetailed) {
    this.onDeleteMovie.emit(movie);
  }

  toggleEdit() {
    this.isEditing = !this.isEditing;
  }

  onUpdate() {
    if (!this.editTitle || !this.editDurationMinutes || !this.editReleaseYear) {
      alert('Please fill out all fields');
      return;
    }

    const updatedMovie: MovieUpdate = {
      title: this.editTitle,
      description: '', // Add a description property
      durationMinutes: this.editDurationMinutes,
      releaseYear: this.editReleaseYear
    };

    this.onUpdateMovie.emit(updatedMovie);
    this.toggleEdit();
  }
}