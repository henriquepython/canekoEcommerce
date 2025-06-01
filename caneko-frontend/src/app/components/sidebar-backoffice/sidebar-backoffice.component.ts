import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ISideBarBackoffice } from '../../models/sidebarBackofficeButtons';

@Component({
  selector: 'app-sidebar-backoffice',
  imports: [],
  templateUrl: './sidebar-backoffice.component.html',
  styleUrl: './sidebar-backoffice.component.scss'
})

export class SidebarBackofficeComponent {
    items: ISideBarBackoffice[] = [
      {name: "Início", path: "./assets/botao-de-inicio.png", route: "init"},
      {name: "Dashboard", path: "./assets/painel.png", route: "dashboard"},
      {name: "Adicionar Produto", path: "./assets/mais.png", route: "add"}, 
      {name: "Editar Produto", path: "./assets/editar.png", route: "edit"},
      {name: "Estoque", path: "./assets/trabalhador-carregando-caixas.png", route: "stock"},
      {name: "Pedido", path: "./assets/lista-de-controle.png", route: "order"},
      {name: "Relatório", path: "./assets/relatorio.png", route: "report"},
      {name: "Configurações", path: "./assets/painel-de-controle.png", route: "config"}
    ]

    @Output() selectorPageEmit = new EventEmitter<string>();

    handleBackofficePage(route: string) {
      this.selectorPageEmit.emit(route);
    }
}
