import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TabViewModule } from 'primeng/tabview';
import { CardModule } from 'primeng/card';
import { ButtonModule } from 'primeng/button';
import { QuestionPaperEditComponent } from './question-paper-edit.component';
import { QuestionPaperEditRoutingModule } from './question-paper-routing.module';
import { FormsModule } from '@angular/forms';
import {InputTextModule} from 'primeng/inputtext';
import { HttpClientModule } from '@angular/common/http';
import { DropdownModule } from 'primeng/dropdown';
import {InputTextareaModule} from 'primeng/inputtextarea';
import {FileUploadModule} from 'primeng/fileupload';
import {TableModule} from 'primeng/table';
import {InputNumberModule} from 'primeng/inputnumber';
import {ToastModule} from 'primeng/toast';
import { MessageService } from 'primeng/api';



@NgModule({
  declarations: [
    QuestionPaperEditComponent
  ],
  imports: [
    CommonModule,
    TabViewModule,
    CardModule,
    ButtonModule,
    QuestionPaperEditRoutingModule,
    FormsModule,
    InputTextModule,
    HttpClientModule,
    DropdownModule,
    InputTextareaModule,
    FileUploadModule,
    TableModule,
    InputNumberModule,
    ToastModule
  ],
  providers: [MessageService],
  exports: [QuestionPaperEditComponent]
})
export class QuestionPaperEditModule { }
