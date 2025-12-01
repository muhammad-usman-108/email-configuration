import { Component, Input, OnChanges } from '@angular/core';
import { EmailConfiguration } from '../../models/email-configuration';
import { EmailService } from '../../services/email.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-email-detail',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './email-detail.component.html',
})
export class EmailDetailComponent implements OnChanges {
  @Input() email?: EmailConfiguration;
  details?: EmailConfiguration;

  constructor(private emailService: EmailService) {}

  ngOnChanges(): void {
    if (this.email?.id) {
      this.emailService.getById(this.email.id).subscribe(data => {
        this.details = data;
      });
    }
  }
}
