import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { FacultyLoginComponent } from 'src/Faculty/faculty-login/faculty-login.component';

@NgModule({
  declarations: [
    AppComponent,
    FacultyLoginComponent,
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
