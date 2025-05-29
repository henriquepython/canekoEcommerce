import { Routes } from '@angular/router';
import { BackofficeComponent } from './pages/backoffice/backoffice.component';

export const routes: Routes = [
    {
        path: "",
        component: BackofficeComponent
    },
    {
        path: "backoffice",
        component: BackofficeComponent
    }
];
