import { Component, EventEmitter, inject, Input, Output } from '@angular/core';
import { Subject, takeUntil } from 'rxjs';
import { PaginationComponent } from '../../pagination/pagination.component';
import { SearchBarComponent } from '../../search-bar/search-bar.component';
import { BrandService } from '../../../services/brand.service';
import { ETypeConfig } from '../../../utils/enums/typeConfig';
import { CategoryService } from '../../../services/category.service';
import { RecommendService } from '../../../services/recommend.service';
import { SupplierService } from '../../../services/supplier.service';
import { ColorItemService } from '../../../services/color-item.service';
import { ManufacturerService } from '../../../services/manufacturer.service';
import { IFilterInput, IFilterViewModel } from '../../../models/generic';
import { ConfigurationEditModalComponent } from '../configuration-edit-modal/configuration-edit-modal.component';

@Component({
  selector: 'app-configuration-modal',
  imports: [PaginationComponent, SearchBarComponent, ConfigurationEditModalComponent],
  templateUrl: './configuration-modal.component.html',
  styleUrl: './configuration-modal.component.scss'
})
export class ConfigurationModalComponent {

  private _brandService = inject(BrandService);
  private _categoryService = inject(CategoryService);
  private _recommendService = inject(RecommendService);
  private _supplierService = inject(SupplierService);
  private _colorItemService = inject(ColorItemService);
  private _manufacturerService = inject(ManufacturerService);
  private unsub$ = new Subject<void>();

  @Output() CloseConfigModalEmit = new EventEmitter<boolean>();
  @Input() typeConfig: ETypeConfig = ETypeConfig.Brand;
  
  items: IFilterViewModel[]= [];
   
  filterDefault: IFilterInput = {
    search: '',
    pageNumber: 1,
    pageSize: 12
  } 

  currentPage: number = 1;
  search: string = '';
  totalPages: number = 1;
  isEditModal = false;
  isCreated = false;
  itemSelected?: IFilterViewModel = undefined;

  ngOnInit(): void {
    this.filterConfig();
  }

  ngOnDestroy(): void {
    this.unsub$.next();
    this.unsub$.complete();
  }

  closeModal() {
    this.CloseConfigModalEmit.emit(false)
  }

   closeEditModal(input: boolean) {
    this.isEditModal = input;
  }

  handlerServiceConfig() {
    switch (this.typeConfig) {
      case ETypeConfig.Brand:
        return this._brandService;
      case ETypeConfig.Category:
        return this._categoryService;
      case ETypeConfig.Recommends:
        return this._recommendService;
      case ETypeConfig.Supplier:
        return this._supplierService;
      case ETypeConfig.Color:
        return this._colorItemService;
      case ETypeConfig.Manufacturer:
        return this._manufacturerService;
      default:
        throw new Error('Tipo de configuração inválido');
    }
  }

  filterConfig(input?: string, pageNumber: number = 1, pageSize: number = 12) {
    this.currentPage = pageNumber;
    
    if (input) {
      this.search = input;
    }

  return this.handlerServiceConfig().filter({search: this.search, pageNumber: pageNumber, pageSize: pageSize})
    .pipe(takeUntil(this.unsub$))
    .subscribe({
      next: response => {
        this.items = response?.items
        this.totalPages = response.totalPages
      },
      error: erro => console.error('Erro ao enviar:', erro)
    });
  }

  openModal(isCreated: boolean, Product?: IFilterViewModel) {
    if(!isCreated && Product) {
      this.itemSelected = Product;
    }
    
    this.isEditModal = true;
    this.isCreated = isCreated;
  
  }

  disableItem(id: string, isDisable: boolean) {
    const confirm = window.confirm('Você tem certeza que deseja desabilitar este produto?');
    
    if (confirm) {
      this.handlerServiceConfig().disableItem(id, isDisable).subscribe({
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
      this.handlerServiceConfig().deleteItem(id).subscribe({
        next: response => {
          this.handlerServiceConfig().filter(this.filterDefault).subscribe({
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
