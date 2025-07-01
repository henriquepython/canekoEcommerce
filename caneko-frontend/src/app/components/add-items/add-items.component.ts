import { Component, OnDestroy, OnInit, inject } from '@angular/core';
import { Subject, takeUntil } from 'rxjs';
import { IProductFilterInput, IProductFilterViewModel } from '../../models/product';
import { ProductService } from '../../services/product.service';
import { PaginationComponent } from '../pagination/pagination.component';
import { SearchBarComponent } from '../search-bar/search-bar.component';
import { EditItemsComponent } from './edit-items/edit-items.component';

@Component({
  selector: 'app-add-items',
  standalone: true,
  imports: [
    SearchBarComponent,
    EditItemsComponent,
    PaginationComponent
  ],
  templateUrl: './add-items.component.html',
  styleUrl: './add-items.component.scss'
})
export class AddItemsComponent implements OnInit, OnDestroy {
  private _productService = inject(ProductService);
  private unsub$ = new Subject<void>();
  items: IProductFilterViewModel[] = [];
  filterDefault: IProductFilterInput = {
    search: '',
    isStock: true,
    pageNumber: 1,
    pageSize: 8
  }

  currentPage = 1;
  totalPages = 1;
  isEditModal = false;
  isCreated = false;
  search = '';
  ProductSelected?: IProductFilterViewModel = undefined;

  constructor() { }
  
  ngOnInit(): void {
    this._productService.filter(this.filterDefault)
      .pipe(takeUntil(this.unsub$))
      .subscribe({
        next: response => {
          this.items = response.products,
          this.totalPages = response.totalPages
        },
        error: erro => console.error('Erro ao enviar:', erro)
      });
  }
  
  ngOnDestroy(): void {
    this.unsub$.next();
    this.unsub$.complete();
  }

  deleteProduct(id: string) {
    const confirm = window.confirm('Você tem certeza que deseja remover este produto?');
    
    if (confirm) {
      this._productService.deleteProduct(id).subscribe({
        next: response => {
          this._productService.filter(this.filterDefault).subscribe({
            next: responseItem => {
              this.items = responseItem.products
              this.totalPages = response.totalPages
            },
            error: erro => console.error('Erro ao enviar:', erro)
          });
        },
        error: erro => console.error('Erro ao enviar:', erro)
      });
    }    
  }

  disableProduct(id: string, isDisable: boolean) {
    const confirm = window.confirm('Você tem certeza que deseja desabilitar este produto?');
    
    if (confirm) {
      this._productService.disableProduct(id, isDisable).subscribe({
        next: response => {
          const index = this.items.findIndex(p => p.id === id);
          const product = this.items.find(p => p.id === id);
          if (index !== -1 && product) {
            const newList = [...this.items];
            product.deleted = isDisable;
            newList[index] = product;
            this.items = newList;
          }
        },
        error: erro => console.error('Erro ao enviar:', erro)
      });
    }
  }

  filter(input?: string, page: number = 1, isStock: boolean = false) {
    this.currentPage = page;
    
    if (input) {
      this.search = input;
    }

    this._productService.filter({search: input || '', isStock: isStock, pageNumber: page, pageSize: this.filterDefault.pageSize})
    .pipe(takeUntil(this.unsub$))
    .subscribe({
      next: response => {
        this.items = response.products
        this.totalPages = response.totalPages
      },
      error: erro => console.error('Erro ao enviar:', erro)
    });
  }

  openModal(isCreated: boolean, Product?: IProductFilterViewModel) {
    if(!isCreated && Product) {
      this.ProductSelected = Product;
    }
    
    this.isEditModal = true;
    this.isCreated = isCreated;

  }

  closeModal(input: boolean) {
    this.isEditModal = input;
    this.isCreated = false;
  }
}
