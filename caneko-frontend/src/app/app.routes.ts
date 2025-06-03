import { Routes } from '@angular/router';
import { BackofficeComponent } from './pages/backoffice/backoffice.component';
import { HomeComponent } from './pages/home/home.component';

export const routes: Routes = [
    {
        path: "",
        component: HomeComponent,
        title: "Caneko | Canecas que inspiram, variedades que encantam!"
    },
    {
        path: "backoffice",
        component: BackofficeComponent,
        title: "Caneko | Backoffice"
    }
];
