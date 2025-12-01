import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject, tap } from 'rxjs';
import { EmailConfiguration } from '../models/email-configuration';

@Injectable({
  providedIn: 'root'
})
export class EmailService {

  private baseUrl = 'http://localhost:5182/api/EmailConfigurations';

  // Holds the current list of email configurations
  private emailListSubject = new BehaviorSubject<EmailConfiguration[]>([]);
  emailList$ = this.emailListSubject.asObservable();

  constructor(private http: HttpClient) { }

  // Load all & update BehaviorSubject
  getAll(): Observable<EmailConfiguration[]> {
    return this.http.get<EmailConfiguration[]>(this.baseUrl).pipe(
      tap(list => this.emailListSubject.next(list))
    );
  }

  getById(id: number): Observable<EmailConfiguration> {
    return this.http.get<EmailConfiguration>(`${this.baseUrl}/${id}`);
  }

  // Add new configuration then auto-refresh the list
  add(config: EmailConfiguration): Observable<EmailConfiguration> {
    return this.http.post<EmailConfiguration>(this.baseUrl, config).pipe(
      tap(() => {
        // reload list after successful POST
        this.getAll().subscribe();
      })
    );
  }
}
