import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({
    'content-type': 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
  
export class GenericService<CinemaEntity> {
  url: string = "https://localhost:4200/api/"

  constructor(private http: HttpClient) { }
  
  getAlls(endpoint: string): Observable<CinemaEntity[]>{
    return this.http.get<CinemaEntity[]>(this.url+"/"+endpoint)
  }

  delete(idToDelete: number, endpoint: string): Observable<CinemaEntity>{
    return this.http.delete<CinemaEntity>(this.url+"/"+endpoint+"/"+idToDelete)
  }
}
