import { Component } from '@angular/core';
import { EmailService } from '../../services/email.service';
import { EmailConfiguration } from '../../models/email-configuration';
import { FormsModule } from '@angular/forms';

// Angular Material
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-email-add',
  standalone: true,
  imports: [
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatCheckboxModule,
    MatButtonModule,
    MatCardModule
  ],
  templateUrl: './email-add.component.html',
})
export class EmailAddComponent {
  newEmail: EmailConfiguration = {
    name: '',
    watchedFolder: '',
    provider: 'Exchange',
    storeAttachments: false
  };

  constructor(private emailService: EmailService) {}

  addEmail() {
    this.emailService.add(this.newEmail).subscribe(data => {
      alert('Email configuration added!');
      this.newEmail = { name: '', watchedFolder: '', provider: 'Exchange', storeAttachments: false };
    });
  }
}
