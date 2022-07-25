import { RouterModule, Routes } from "@angular/router";
import { NgModule } from "@angular/core";
import { ClinicPageComponent } from "./clinic-page/clinic-page.component";

const routes: Routes = [
    {
        path: 'clinic',
        component: ClinicPageComponent
    }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class ClinicRoutingModule { }
