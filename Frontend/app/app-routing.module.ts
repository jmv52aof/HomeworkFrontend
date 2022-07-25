import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClinicPageComponent } from "./clinic/clinic-page/clinic-page.component";

const routes: Routes = [
    {
				path: '**',
				component: ClinicPageComponent
		}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
