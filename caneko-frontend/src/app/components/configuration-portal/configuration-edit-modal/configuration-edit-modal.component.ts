import { Component, EventEmitter, inject, Input, OnDestroy, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { IFilterViewModel } from '../../../models/generic';
import { BrandService } from '../../../services/brand.service';
import { CategoryService } from '../../../services/category.service';
import { RecommendService } from '../../../services/recommend.service';
import { SupplierService } from '../../../services/supplier.service';
import { ColorItemService } from '../../../services/color-item.service';
import { ManufacturerService } from '../../../services/manufacturer.service';
import { Subject } from 'rxjs';
import { ETypeConfig } from '../../../utils/enums/typeConfig';

@Component({
  selector: 'app-configuration-edit-modal',
  imports: [],
  templateUrl: './configuration-edit-modal.component.html',
  styleUrl: './configuration-edit-modal.component.scss'
})
export class ConfigurationEditModalComponent implements OnDestroy {
  private _brandService = inject(BrandService);
  private _categoryService = inject(CategoryService);
  private _recommendService = inject(RecommendService);
  private _supplierService = inject(SupplierService);
  private _colorItemService = inject(ColorItemService);
  private _manufacturerService = inject(ManufacturerService);
  private unsub$ = new Subject<void>();
  @Output() CloseModalEditItemEmit = new EventEmitter<boolean>();
  @Input() IsCreated = false;
  @Input() typeConfig = ETypeConfig.Brand;
  @Input() ItemSelected?: IFilterViewModel = undefined;
  formItem: FormGroup = new FormGroup({
      name: new FormControl(this.ItemSelected?.name ?? '', [Validators.required]),
  });

  ngOnDestroy(): void {
    this.unsub$.next();
    this.unsub$.complete();
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

  closeEditModal() {
    this.CloseModalEditItemEmit.emit(false)
  }

  createOrUpdateItem() {
    if (this.formItem.valid) {
      if (this.IsCreated) {
        this.handlerServiceConfig().createItem(this.formItem.value).subscribe({
          next: (response) => {
            console.log('Item created successfully:', response);
          },
          error: (error) => {
            console.error('Error creating item:', error);
          }
        });

      } else {
        if(!this.ItemSelected?.id) return console.error('Item ID is required for update');
        const updatedItem =this.ItemSelected;
        updatedItem.name = this.formItem.value; // Ensure the ID is preserved
        this.handlerServiceConfig().updateItem(updatedItem.id, updatedItem).subscribe({
          next: (response) => {
            console.log('Item created successfully:', response);
          },
          error: (error) => {
            console.error('Error creating item:', error);
          }
        });
      }
      this.closeEditModal();
    } else {
      console.error('Form is invalid');
    }
  }
}
