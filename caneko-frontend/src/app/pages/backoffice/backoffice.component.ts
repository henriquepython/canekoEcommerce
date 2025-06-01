import { Component, Output, inject } from '@angular/core';
import { SidebarBackofficeComponent } from '../../components/sidebar-backoffice/sidebar-backoffice.component';
import { AddItemsComponent } from '../../components/add-items/add-items.component';
import { EditItemComponent } from '../../components/edit-item/edit-item.component';
import { StockItemComponent } from '../../components/stock-item/stock-item.component';
import { OrderBackofficeComponent } from '../../components/order-backoffice/order-backoffice.component';
import { ReportBackofficeComponent } from '../../components/report-backoffice/report-backoffice.component';
import { InitBackofficeComponent } from '../../components/init-backoffice/init-backoffice.component';
import { DashboardComponent } from '../../components/dashboard/dashboard.component';
import { ConfigurationPortalComponent } from '../../components/configuration-portal/configuration-portal.component';

@Component({
  selector: 'app-backoffice',
  standalone: true,
  imports: [
    SidebarBackofficeComponent,
    AddItemsComponent,
    EditItemComponent,
    StockItemComponent,
    OrderBackofficeComponent,
    ReportBackofficeComponent,
    InitBackofficeComponent,
    DashboardComponent,
    ConfigurationPortalComponent
  ],
  templateUrl: './backoffice.component.html',
  styleUrl: './backoffice.component.scss'
})

export class BackofficeComponent {
  routePage: string = '';

  setRoutePageEvent = (routePage: string) => {
    this.routePage = routePage;
  }
}
