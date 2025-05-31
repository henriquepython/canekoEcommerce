import { Component } from '@angular/core';
import { FooterPrimaryComponent } from './footer-primary/footer-primary.component';
import { FooterSecondaryComponent } from './footer-secondary/footer-secondary.component';

@Component({
  selector: 'app-footer',
  standalone: true,
  imports: [
    FooterPrimaryComponent, 
    FooterSecondaryComponent
  ],
  templateUrl: './footer.component.html',
  styleUrl: './footer.component.scss'
})
export class FooterComponent {

  returnTop = () => {
    window.scrollTo({
      top: 0,
      behavior: "smooth"
    });
  };
}
