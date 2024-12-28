import { Component } from '@angular/core';

@Component({
  selector: 'app-document',
  templateUrl: './document.component.html',
  styleUrl: './document.component.css'
})
export class DocumentComponent {
  isclosed: boolean = false


  toggleVisibility(): void {
    this.isclosed = !this.isclosed;
  }
}
