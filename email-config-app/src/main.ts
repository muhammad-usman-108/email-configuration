import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app/app.component';
import { importProvidersFrom } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { provideRouter } from '@angular/router';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';

bootstrapApplication(AppComponent, {
  providers: [
    importProvidersFrom(HttpClientModule), provideAnimationsAsync()
    // optionally: importProvidersFrom(RouterModule.forRoot([])) if routing is needed
  ]
})
.catch(err => console.error(err));
