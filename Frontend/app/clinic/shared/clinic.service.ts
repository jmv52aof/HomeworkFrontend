import { Injectable } from "@angular/core";
import { IDoctor } from './doctor.interface';
import { IPatient } from "../shared/patient.interface";
import { IVoucher } from "../shared/voucher.interface";
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";

@Injectable()
export class ClinicService {
    private readonly apiUrl: string = 'http://localhost:4200';

    constructor(private httpClient: HttpClient) {
    }

    public getDoctors(): Observable<IDoctor[]> {
				return this.httpClient.get<IDoctor[]>(`${this.apiUrl}/doctor`);
		}

		public getPatients(): Observable<IPatient[]> {
				return this.httpClient.get<IPatient[]>(`${this.apiUrl}/patient`);
		}

		public getVouchers(): Observable<IVoucher[]> {
				return this.httpClient.get<IVoucher[]>(`${this.apiUrl}/voucher`);
		}

		public deletePatientById(id: number): void {
				this.httpClient.get(`${this.apiUrl}/patient/delete/${id}`).subscribe();
		}

		public updatePatient(patient: IPatient): void {
				this.httpClient.get(`${this.apiUrl}/patient/update/name/${patient.id}/${patient.name}`).subscribe();
				this.httpClient.get(`${this.apiUrl}/patient/update/phonenumber/${patient.id}/${patient.phoneNumber}`).subscribe();
		}

		public addPatient(patient: IPatient): void {
				this.httpClient.get(`${this.apiUrl}/patient/add/${patient.name}/${patient.birthDate.toISOString()}/${patient.phoneNumber}`).subscribe();
		}

		public deleteVoucherById(id: number): void {
				this.httpClient.get(`${this.apiUrl}/voucher/delete/${id}`).subscribe();
		}

		public addVoucher(voucher: IVoucher): void {
				this.httpClient.get(`${this.apiUrl}/voucher/add/${voucher.receptionTime}/${voucher.doctorId}/${voucher.patientId}`).subscribe();
		}
}
