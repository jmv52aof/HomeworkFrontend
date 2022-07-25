import { Component, EventEmitter, Input, Output } from "@angular/core";
import { IDoctor } from "../shared/doctor.interface";
import { MatExpansionModule } from '@angular/material/expansion';

@Component({
    selector: 'doctor-item',
    templateUrl:'./doctor-item.component.html',
    styleUrls: ['./doctor-item.component.scss']
})

export class DoctorItemComponent {
    @Input() public item: IDoctor;
    @Output() public more: EventEmitter<IDoctor> = new EventEmitter<IDoctor>();
}
