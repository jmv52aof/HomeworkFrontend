import { NgModule } from "@angular/core";
import { ClinicPageComponent } from "./clinic-page/clinic-page.component";
import { DoctorItemComponent } from "./doctor-item/doctor-item.component";
import { PatientItemComponent } from "./patient-item/patient-item.component";
import { VoucherItemComponent } from "./voucher-item/voucher-item.component";
import { ClinicRoutingModule } from "./clinic-routing.module";
import { MatCardModule } from "@angular/material/card";
import { MatButtonModule } from "@angular/material/button";
import { MatListModule } from "@angular/material/list";
import { CommonModule } from "@angular/common";
import { MatIconModule } from "@angular/material/icon";
import { ClinicService } from "./shared/clinic.service";
import { HttpClientModule } from "@angular/common/http";
import { ReactiveFormsModule } from "@angular/forms";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from "@angular/material/input";
import { MatTabsModule } from '@angular/material/tabs';
import { MatTableModule } from '@angular/material/table';
import { MatExpansionModule } from '@angular/material/expansion';
import { FormsModule } from '@angular/forms';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule, MatRippleModule } from '@angular/material/core';

@NgModule({
    declarations: [
        ClinicPageComponent,
        DoctorItemComponent,
        PatientItemComponent,
        VoucherItemComponent
    ],
    imports: [
        HttpClientModule,
        MatButtonModule,
        MatCardModule,
        MatListModule,
        ClinicRoutingModule,
        CommonModule,
        MatIconModule,
        ReactiveFormsModule,
        MatFormFieldModule,
        MatInputModule,
        MatTabsModule,
        MatTableModule,
        MatExpansionModule,
        FormsModule,
				MatDatepickerModule,
				MatNativeDateModule,
				MatRippleModule
    ],
    providers: [
        ClinicService
    ]
})
export class ClinicModule {
}
