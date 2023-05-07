import { NgModule } from "@angular/core";
import { AdminComponent } from "./admin.component";
import { AdminRoutingModule } from "./admin-routing.module";
import {TabViewModule} from "primeng/tabview";
import {CardModule} from 'primeng/card';
import {AccordionModule} from 'primeng/accordion';
import { ButtonModule } from "primeng/button";
import { InputTextModule } from "primeng/inputtext";
import { DropdownModule } from "primeng/dropdown";

@NgModule({
    imports:[AdminRoutingModule,
             TabViewModule,
             CardModule,
             AccordionModule,
             ButtonModule,
             InputTextModule,
             DropdownModule],
    declarations: [AdminComponent],
    bootstrap: [AdminComponent],
    providers: []
})

export class AdminModule {}