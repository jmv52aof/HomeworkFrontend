import { Component, OnInit } from '@angular/core';
import { IDoctor } from "../shared/doctor.interface";
import { IPatient } from "../shared/patient.interface";
import { IVoucher } from "../shared/voucher.interface";
import { ClinicService } from "../shared/clinic.service";
import { AbstractControl, FormControl, FormGroup, Validators } from "@angular/forms";

@Component({
    templateUrl: './clinic-page.component.html',
    styleUrls: ['./clinic-page.component.scss'],
    providers: [ClinicService]
})

export class ClinicPageComponent implements OnInit {
		displayedColumns: string[] = ['id', 'name', 'specialisation', 'yearsOfExperience'];
    public doctors: IDoctor[];
		public patients: IPatient[];
		public vouchers: IVoucher[];
		public patient: IPatient;
		public voucher: IVoucher;

    public form: FormGroup;

    constructor(private clinicService: ClinicService) {
        this.reloadDoctors();
        this.reloadPatients();
        this.reloadVouchers();
    }

    public reloadDoctors(): void {
        this.clinicService.getDoctors().subscribe(items => {
            this.doctors = items;
        })
    }

    public reloadPatients(): void {
        this.clinicService.getPatients().subscribe(items => {
            this.patients = items;
        })
		}

		public reloadVouchers(): void {
				this.clinicService.getVouchers().subscribe(items => {
						this.vouchers = items;
				})
		}

		public addPatient(): void {
				this.clinicService.addPatient(this.patient);
				this.reloadPatients();
		}

		public addVoucher(): void {
				this.clinicService.addVoucher(this.voucher);
				this.reloadVouchers();
		}

    public ngOnInit(): void {
				this.patient = {} as IPatient;
				this.voucher = {} as IVoucher;
        this.form = new FormGroup({
            title: new FormControl(null, [Validators.required])
        });
    }
}
