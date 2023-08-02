import { Routes, RouterModule } from "@angular/router";
import { NgModule } from "@angular/core";


const routes: Routes = [
    {
        path: '',
        children: [
            {
                path: '',
                redirectTo: '/home',
                pathMatch: 'full'
            },
            {
                path: 'home',
                loadChildren: () => import('./Faculty/faculty-main/faculty-main.module').then(module => module.FacultyMainModule)
            }
        ]
    }, {
        path: 'questionPaperEdit/:id',
        loadChildren: () => import('./question-paper-edit/question-paper-edit.module').then(module => module.QuestionPaperEditModule)
    }, {
        path: 'admin',
        loadChildren: () => import('./Admin/admin/admin.module').then(module => module.AdminModule)
    }
]

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule { }