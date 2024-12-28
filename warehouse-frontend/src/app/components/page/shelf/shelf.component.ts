import { Component } from '@angular/core';

@Component({
  selector: 'app-shelf',
  templateUrl: './shelf.component.html',
  styleUrl: './shelf.component.css'
})
export class ShelfComponent {
  isclosed: boolean = false


  toggleVisibility(): void {
    this.isclosed = !this.isclosed;
  }
}
