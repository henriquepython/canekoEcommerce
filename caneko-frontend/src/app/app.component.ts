import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { BackofficeComponent } from './pages/backoffice/backoffice.component';
import { HeaderComponent } from './components/header/header.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, HeaderComponent, BackofficeComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'Caneko';
}
