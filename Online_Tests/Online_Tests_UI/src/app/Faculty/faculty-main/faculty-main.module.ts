import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FacultyMainComponent } from './faculty-main.component';
import { FacultyMainRoutingModule } from './faculty-main-routing.module';
import { TabViewModule } from 'primeng/tabview';
import { CardModule } from 'primeng/card';
import { ButtonModule } from 'primeng/button';
import { DropdownModule } from 'primeng/dropdown';
import { FormsModule } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { TableModule } from 'primeng/table';
import {MultiSelectModule} from 'primeng/multiselect';
import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';
import {CalendarModule} from 'primeng/calendar';


@NgModule({
  declarations: [
    FacultyMainComponent
  ],
  imports: [
    CommonModule,
    FacultyMainRoutingModule,
    TabViewModule,
    CardModule,
    ButtonModule,
    DropdownModule,
    FormsModule,
    InputTextModule,
    TableModule,
    MultiSelectModule,
    ToastModule,
    CalendarModule
  ],
  providers: [MessageService],
  bootstrap: [FacultyMainComponent]
})
export class FacultyMainModule { }