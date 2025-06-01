import { Routes } from '@angular/router';
import { BackofficeComponent } from './pages/backoffice/backoffice.component';
import { HomeComponent } from './pages/home/home.component';

export const routes: Routes = [
    {
        path: "",
        component: HomeComponent
    },
    {
        path: "backoffice",
        component: BackofficeComponent
    }
];
