import { Component, EventEmitter, inject, Input, Output } from '@angular/core';
import { Subject, takeUntil } from 'rxjs';
import { PaginationComponent } from '../../pagination/pagination.component';
import { SearchBarComponent } from '../../search-bar/search-bar.component';
import { BrandService } from '../../../services/brand.service';
import { IBrandFilterInput, IBrandFilterViewModel } from '../../../models/brand';
import { ETypeConfig } from '../../../utils/enums/typeConfig';

@Component({
  selector: 'app-configuration-modal',
  imports: [PaginationComponent, SearchBarComponent],
  templateUrl: './configuration-modal.component.html',
  styleUrl: './configuration-modal.component.scss'
})
export class ConfigurationModalComponent {

  private _brandService = inject(BrandService);
  private unsub$ = new Subject<void>();

  @Output() CloseModalEmit = new EventEmitter<boolean>();
  @Input() typeConfig: ETypeConfig = ETypeConfig.Brand;
  
  items: IBrandFilterViewModel[] = [];
  filterDefault: IBrandFilterInput = {
    search: '',
    pageNumber: 1,
    pageSize: 12
  } 
  currentPage: number = 1;
  search: string = '';
  totalPages: number = 1;
  isEditModal = false;
  isCreated = false;
  itemSelected?: IBrandFilterViewModel = undefined;

  ngOnInit(): void {
    this.filterBrands();
  }

  ngOnDestroy(): void {
    this.unsub$.next();
    this.unsub$.complete();
  }

  closeModal() {
    this.CloseModalEmit.emit(false)
  }

  filterBrands(input?: string, pageNumber: number = 1, pageSize: number = 12) {
    this.currentPage = pageNumber;
    
    if (input) {
      this.search = input;
    }

  return this._brandService.filter(this.filterDefault)
    .pipe(takeUntil(this.unsub$))
    .subscribe({
      next: response => {
        this.items = response?.items
        this.totalPages = response.totalPages
      },
      error: erro => console.error('Erro ao enviar:', erro)
    });
  }

  openModal(isCreated: boolean, Product?: IBrandFilterViewModel) {
      if(!isCreated && Product) {
        this.itemSelected = Product;
      }
      
      this.isEditModal = true;
      this.isCreated = isCreated;
  
  }

  disableItem(id: string, isDisable: boolean) {
    const confirm = window.confirm('Você tem certeza que deseja desabilitar este produto?');
    
    if (confirm) {
      this._brandService.disableItem(id, isDisable).subscribe({
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

  deleteItem(id: string) {
    const confirm = window.confirm('Você tem certeza que deseja remover este produto?');
    
    if (confirm) {
      this._brandService.deleteItem(id).subscribe({
        next: response => {
          this._brandService.filter(this.filterDefault).subscribe({
            next: responseItem => {
              this.items = responseItem.items
              this.totalPages = response.totalPages
            },
            error: erro => console.error('Erro ao enviar:', erro)
          });
        },
        error: erro => console.error('Erro ao enviar:', erro)
      });
    }    
  }
}
