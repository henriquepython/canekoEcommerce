import { Component } from '@angular/core';
import { ConfigurationModalComponent } from './configuration-modal/configuration-modal.component';
import { ETypeConfig } from '../../utils/enums/typeConfig';

@Component({
  selector: 'app-configuration-portal',
  standalone: true,
  imports: [ConfigurationModalComponent],
  templateUrl: './configuration-portal.component.html',
  styleUrl: './configuration-portal.component.scss'
})
export class ConfigurationPortalComponent {
  isEditConfigModal = false;
  typeConfig: ETypeConfig = ETypeConfig.Brand;
  configs = [
     { name: "Marca", type: ETypeConfig.Brand},
     { name: "Categoria", type: ETypeConfig.Category},
     { name: "Fornecedor", type: ETypeConfig.Supplier},
     { name: "Cores", type: ETypeConfig.Color},
     { name: "Fabricante", type: ETypeConfig.Manufacturer},
     { name: "Uso Recomendado", type: ETypeConfig.Recommends}
    ];
  
  closeModal(input: boolean) {
    this.isEditConfigModal = input;
  }

  openModal(inputType: ETypeConfig) {
    this.typeConfig = inputType;
    this.isEditConfigModal = true;
  }
}
