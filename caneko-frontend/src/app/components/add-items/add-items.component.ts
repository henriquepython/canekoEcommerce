import { Component, inject } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { SearchBarComponent } from '../search-bar/search-bar.component';

@Component({
  selector: 'app-add-items',
  standalone: true,
  imports: [SearchBarComponent],
  templateUrl: './add-items.component.html',
  styleUrl: './add-items.component.scss'
})
export class AddItemsComponent {
  private productService = inject(ProductService);
}
