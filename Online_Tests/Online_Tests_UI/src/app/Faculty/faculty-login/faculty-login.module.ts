import { NgModule } from '@angular/core';
import { FacultyLoginRoutingModule } from './faculty-login-routing.module';
import { FacultyLoginComponent } from './faculty-login.component';


@NgModule({
  declarations: [
    FacultyLoginComponent,
  ],
  imports: [
    FacultyLoginRoutingModule
  ],
  providers: [],
  bootstrap: [FacultyLoginComponent]
})
export class FacultyLoginModule { }
