import { Component, EventEmitter, Input, Output } from "@angular/core";
import { IVoucher } from "../shared/voucher.interface";
import { MatExpansionModule } from '@angular/material/expansion';
import { ClinicService } from "../shared/clinic.service";

@Component({
    selector: 'voucher-item',
    templateUrl:'./voucher-item.component.html',
    styleUrls: ['./voucher-item.component.scss'],
    providers: [ClinicService]
})

export class VoucherItemComponent {
    constructor(private clinicService: ClinicService) {

    }

    @Input() public item: IVoucher;
    @Output() public delete: EventEmitter<IVoucher> = new EventEmitter<IVoucher>();

    public deleteClicked(): void {
				this.deleteVoucher(this.item.id);
        this.delete.emit(this.item);
    }

    public deleteVoucher(id: number): void {
				this.clinicService.deleteVoucherById(id);
		}

}
