import { Component } from '@angular/core';
import { ISideBarBackoffice } from '../../models/sidebarBackofficeButtons';

@Component({
  selector: 'app-sidebar-backoffice',
  imports: [],
  templateUrl: './sidebar-backoffice.component.html',
  styleUrl: './sidebar-backoffice.component.scss'
})
export class SidebarBackofficeComponent {
    items: ISideBarBackoffice[] = [
      {name: "Adicionar Produto", path: "./assets/mais.png"},
      {name: "Editar Produto", path: "./assets/editar.png"},
      {name: "Estoque", path: "./assets/trabalhador-carregando-caixas.png"},
      {name: "Pedido", path: "./assets/lista-de-controle.png"},
      {name: "Relatório", path: "./assets/relatorio.png"}
    ]
}
