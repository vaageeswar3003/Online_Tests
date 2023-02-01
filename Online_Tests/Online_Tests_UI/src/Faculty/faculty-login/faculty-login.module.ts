import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FacultyLoginComponent } from './faculty-login.component';
import {PanelModule} from 'primeng/panel';


@NgModule({
  declarations: [
    PanelModule
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [FacultyLoginComponent]
})
export class AppModule { }
