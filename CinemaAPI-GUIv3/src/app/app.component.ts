import { Component } from '@angular/core';
import { FooterComponent } from './components/footer/footer.component';
import { HeaderComponent } from './components/header/header.component';
import { MovieComponent } from './components/movies/movies.component';
import { RouterOutlet, RouterModule, RouterLink, Routes } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, RouterModule, RouterLink, FooterComponent, HeaderComponent, MovieComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'CinemaAPI-GUIv3';
}
