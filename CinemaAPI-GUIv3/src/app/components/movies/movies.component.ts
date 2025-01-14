import { Component, OnInit } from '@angular/core';
import { MovieItemComponent } from '../movie-item/movie-item.component';
import { CommonModule } from '@angular/common';
import { MOVIES } from '../../mock-movies';
import { Movie } from '../../Movie';

@Component({
  selector: 'app-movie',
  imports: [CommonModule, MovieItemComponent],
  templateUrl: './movies.component.html',
  styleUrl: './movies.component.css'
})
export class MovieComponent implements OnInit {
  movies: Movie[] = MOVIES;

  constructor() { 

  }

  ngOnInit(): void {
    
  }
  
}
