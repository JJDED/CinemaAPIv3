import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-header',
  imports: [CommonModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {
  title: string = 'Matrix\' Black Box Cinema';

  constructor() { 

  }

  ngOnInit(): void {
    
  }
}
