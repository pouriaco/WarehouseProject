import { Component } from '@angular/core';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.css'
})
export class SidebarComponent {
  isclosed: boolean = false


  toggleVisibility(): void {
    this.isclosed = !this.isclosed;
  }
}
