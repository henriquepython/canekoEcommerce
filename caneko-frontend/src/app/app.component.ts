import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { BackofficeComponent } from './pages/backoffice/backoffice.component';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';

@Component({
  selector: 'app-root',
  imports: [
    RouterOutlet,
    HeaderComponent,
    BackofficeComponent,
    FooterComponent
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'Caneko';
}
