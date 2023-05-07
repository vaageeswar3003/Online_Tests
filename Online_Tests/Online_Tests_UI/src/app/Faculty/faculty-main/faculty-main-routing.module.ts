import { Routes,RouterModule } from "@angular/router";
import { NgModule } from "@angular/core";
import { FacultyMainComponent } from "./faculty-main.component";


const routes:Routes = [
    {
        path: '',
        component:  FacultyMainComponent 
    }
]

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
  })

export class FacultyMainRoutingModule {}