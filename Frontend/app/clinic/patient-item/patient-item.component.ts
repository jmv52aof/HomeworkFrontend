import { Component, EventEmitter, Input, Output } from "@angular/core";
import { IPatient } from "../shared/patient.interface";
import { MatExpansionModule } from '@angular/material/expansion';
import { ClinicService } from "../shared/clinic.service";

@Component({
    selector: 'patient-item',
    templateUrl:'./patient-item.component.html',
    styleUrls: ['./patient-item.component.scss'],
    providers: [ClinicService]
})

export class PatientItemComponent {
    constructor(private clinicService: ClinicService) {

    }

    @Input() public item: IPatient;
    @Output() public delete: EventEmitter<IPatient> = new EventEmitter<IPatient>();
    @Output() public change: EventEmitter<IPatient> = new EventEmitter<IPatient>();

    public deleteClicked(): void {
				this.deletePatient(this.item.id);
        this.delete.emit(this.item);
    }

    public deletePatient(id: number): void {
				this.clinicService.deletePatientById(id);
		}

		public changeClicked(): void {
				this.clinicService.updatePatient(this.item);
				this.change.emit(this.item);
		}
}
