import { Component, OnInit } from '@angular/core';
import { EmailService } from '../../services/email.service';
import { EmailConfiguration } from '../../models/email-configuration';
import { EmailDetailComponent } from '../email-detail/email-detail.component';
import { CommonModule } from '@angular/common';

import { MatListModule } from '@angular/material/list';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-email-list',
  standalone: true,
  imports: [
    CommonModule, 
    EmailDetailComponent, 
    MatListModule,
    MatCardModule
  ],
  templateUrl: './email-list.component.html',
})
export class EmailListComponent implements OnInit {
  emails: EmailConfiguration[] = [];
  selectedEmail?: EmailConfiguration;

  constructor(private emailService: EmailService) { }

  ngOnInit(): void {
    this.emailService.emailList$.subscribe(data => {
      this.emails = data;
    });
    
    this.emailService.getAll().subscribe();
  }

  loadEmails() {
    this.emailService.getAll().subscribe(data => {
      this.emails = data;
    });
  }

  selectEmail(email: EmailConfiguration) {
    this.selectedEmail = email;
  }
}
