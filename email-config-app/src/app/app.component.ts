import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { EmailListComponent } from './components/email-list/email-list.component';
import { EmailAddComponent } from './components/email-add/email-add.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    EmailListComponent,
    EmailAddComponent
  ],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'email-config-app';
}
