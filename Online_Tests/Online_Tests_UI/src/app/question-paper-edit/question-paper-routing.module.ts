import { Routes,RouterModule } from "@angular/router";
import { NgModule } from "@angular/core";
import { QuestionPaperEditComponent } from "./question-paper-edit.component";

const routes:Routes = [
    {
        path: '',
        component:  QuestionPaperEditComponent 
    }
]

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
  })

export class QuestionPaperEditRoutingModule {}