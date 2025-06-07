import { Component, OnDestroy, OnInit, inject } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { SearchBarComponent } from '../search-bar/search-bar.component';
import { IProductFilterViewModel, mockProductFilter } from '../../models/product';
import { Subject, takeUntil } from 'rxjs';
import { AsyncPipe } from '@angular/common';

@Component({
  selector: 'app-add-items',
  standalone: true,
  imports: [SearchBarComponent, AsyncPipe],
  templateUrl: './add-items.component.html',
  styleUrl: './add-items.component.scss'
})
export class AddItemsComponent {
  private _productService = inject(ProductService);
  // items$ = [mockProductFilter,mockProductFilter,mockProductFilter];
  items$ = this._productService.filter({search: '', isStock: false, pageNumber: 1, pageSize: 10});
  productsMock = [mockProductFilter, mockProductFilter, mockProductFilter, mockProductFilter, mockProductFilter, mockProductFilter, mockProductFilter];

  constructor() {}

  async filter() {
    return await this._productService.filter({search: '', isStock: false, pageNumber: 1, pageSize: 10});
  }
}
