import { Routes,RouterModule } from "@angular/router";
import { NgModule } from "@angular/core";
import { FacultyLoginComponent } from "./faculty-login.component";


const routes:Routes = [
    {
        path: '',
        component:  FacultyLoginComponent 
    }
]

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })

export class FacultyLoginRoutingModule {}