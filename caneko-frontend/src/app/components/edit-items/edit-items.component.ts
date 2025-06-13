import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-edit-items',
  standalone: true,
  imports: [],
  templateUrl: './edit-items.component.html',
  styleUrl: './edit-items.component.scss'
})
export class EditItemsComponent {
  @Output() CloseModalEditItemEmit = new EventEmitter<boolean>();

  closeModal() {
    this.CloseModalEditItemEmit.emit(false)
  }
}
