import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { ChatWindowComponent } from "./component/chat-window/chat-window.component";

@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.component.html',
    styleUrl: './app.component.scss',
    imports: [ChatWindowComponent]
})
export class AppComponent {
  title = 'chat-application';
}
