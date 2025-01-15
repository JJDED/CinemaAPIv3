import { Component, OnInit } from '@angular/core';
import { MovieItemComponent } from '../movie-item/movie-item.component';
import { AddMovieComponent } from '../add-movie/add-movie.component';
import { UpdateMovieComponent } from '../update-movie/update-movie.component';
import { CommonModule } from '@angular/common';
import { MovieSimple, MovieDetailed, MovieCreate, MovieUpdate } from '../../models/movie';
import { MovieService } from '../../service/movie.service';

@Component({
  selector: 'app-movie',
  imports: [CommonModule, MovieItemComponent, AddMovieComponent, UpdateMovieComponent],
  templateUrl: './movies.component.html',
  styleUrl: './movies.component.css'
})
export class MovieComponent implements OnInit {
  movies: MovieDetailed[] = [];
  selectedMovie: MovieDetailed | null = null;

  constructor(private movieService: MovieService) { 

  }

  ngOnInit(): void {
    this.movieService.getAll()
      .subscribe(
      movies => this.movies = movies
    );
  }

  load(): void {
    this.movieService.getAll().subscribe(
      movies => this.movies = movies
    );
  }
  
  getMovie(id: number): void {
    this.movieService.getById(id).subscribe(
      movie => console.log(movie)
    );
  }

  createMovie(movie: MovieCreate): void {
    this.movieService
      .create(movie)
      .subscribe((newMovie) =>
      {
        this.movies.push(newMovie)
        console.log(newMovie)
        this.load();
      });
  }

  // updateMovie(id: number, movie: MovieUpdate): void {
  //   this.movieService
  //     .update(id, movie)
  //     .subscribe(() => console.log('Movie updated'));
  //     this.load();
  // };

  updateMovie(movie: MovieUpdate): void {
    if (this.selectedMovie) {
      this.movieService
        .update(this.selectedMovie.id, movie)
        .subscribe(() => {
          console.log('Movie updated');
          this.load();
          this.selectedMovie = null;
        });
    }
  }

  selectMovie(movie: MovieDetailed): void {
    this.selectedMovie = movie;
  }

  toggleReminder(movie: MovieDetailed) {
    this.movieService.update(movie.id, movie).subscribe();
    console.log(movie);
  }

  deleteMovie(id: number): void {
    this.movieService
      .delete(id)
      .subscribe(
        () => this.movies = this.movies.filter((m) => m.id !== id));
        console.log('Movie deleted');
    this.load();
  }
}
