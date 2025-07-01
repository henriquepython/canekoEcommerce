import { Component, EventEmitter, Input, OnChanges, OnDestroy, Output, inject } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Subject } from 'rxjs';
import { IProductFilterViewModel } from '../../../models/product';
import { ProductService } from '../../../services/product.service';

@Component({
  selector: 'app-edit-items',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './edit-items.component.html',
  styleUrl: './edit-items.component.scss'
})
export class EditItemsComponent implements OnChanges, OnDestroy {
  private _productService = inject(ProductService)
  private unsub$ = new Subject<void>();
  @Output() CloseModalEditItemEmit = new EventEmitter<boolean>();
  @Input() IsCreated = false;
  @Input() Product: IProductFilterViewModel | undefined = undefined;
  formProduct: FormGroup = new FormGroup({
      name: new FormControl('', [Validators.required]),
      description: new FormControl('', [Validators.required]),
      category: new FormControl('', [Validators.required]),
      brand: new FormControl('', [Validators.required]),
      imagePrincipalUrl: new FormControl('', [Validators.required]),
      imageSecondaryUrl: new FormControl([]),
      manufacturer: new FormControl(''),
      supplierSale: new FormControl(''),
      technicalDescription: new FormControl(''),
      heightProduct: new FormControl(null),
      widthProduct: new FormControl(null),
      weightProduct: new FormControl(null),
      typeColor: new FormControl(null),
      typeSize: new FormControl(null),
      useRecommend: new FormControl(null),
      isHighlight: new FormControl(false),
    });

  ngOnChanges(): void {
    // console.log("desc", this.Product?.description);
    // if (!this.IsCreated) {
    //   this.formProduct.patchValue({
    //     name: this.Product?.name,
    //     description: this.Product?.description,
    //     category: this.Product?.category,
    //     brand: this.Product?.details?.brand,
    //     // imagePrincipalUrl: this.Product?.images?.imagePrincipalUrl,
    //     // imageSecondaryUrl: this.Product?.images?.imageSecondaryUrl,
    //     manufacturer: this.Product?.details?.manufacturer,
    //     supplierSale: this.Product?.details?.supplierSale,
    //     technicalDescription: this.Product?.details?.technicalDescription,
    //     heightProduct: this.Product?.details?.height,
    //     widthProduct: this.Product?.details?.width,
    //     weightProduct: this.Product?.details?.weight,
    //     typeColor: this.Product?.details?.typeColor,
    //     typeSize: this.Product?.details?.typeUnits,
    //     useRecommend: this.Product?.details?.useRecommend,
    //     isHighlight: this.Product?.details?.isHighlight,
    //   })
    // }
  }

  ngOnDestroy(): void {
    this.unsub$.next();
    this.unsub$.complete();
  }

  closeModal() {
    this.CloseModalEditItemEmit.emit(false)
  }

}
