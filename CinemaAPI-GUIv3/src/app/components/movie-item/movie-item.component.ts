import { Component, OnInit, Input } from '@angular/core';
import { Movie } from '../../Movie';

@Component({
  selector: 'app-movie-item',
  imports: [],
  templateUrl: './movie-item.component.html',
  styleUrl: './movie-item.component.css'
})
export class MovieItemComponent implements OnInit {
  @Input() movie!: Movie;

  // split dit array per værdi og lav en liste af dem

  constructor() { 

  }

  ngOnInit(): void {
    
  }

}
