import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { MovieSimple, MovieDetailed, MovieCreate, MovieUpdate } from '../models/movie';
import { inject } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MovieService {

  constructor(private http : HttpClient) {}
  
  getAll(): Observable<MovieDetailed[]> {
    return this.http.get<MovieDetailed[]>(`http://localhost:5021/api/movies`);
  }

  getById(id: number): Observable<MovieDetailed> {
    return this.http.get<MovieDetailed>(`http://localhost:5021/api/movies/${id}`);
  }

  create(movie: MovieCreate): Observable<MovieDetailed> {
    return this.http.post<MovieDetailed>(`http://localhost:5021/api/movies`, movie);
  }

  update(id: number, movie: MovieUpdate): Observable<void> {
    return this.http.put<void>(`http://localhost:5021/api/movies/${id}`, movie);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`http://localhost:5021/api/movies/${id}`);
  }
}

