import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-search-bar',
  standalone: true,
  imports: [],
  templateUrl: './search-bar.component.html',
  styleUrl: './search-bar.component.scss'
})
export class SearchBarComponent {
  @Output() SearchInputEmit = new EventEmitter<string>();
  searchInput = '';

  isInvalidInput(input?: string) {
    return (!input || input === '');
  }

  handleSearch(input: string) {
    if (!input || input === '') return;

    this.SearchInputEmit.emit(input);
  }

  captureText(event: Event) {
    const inputElement = event.target as HTMLInputElement;
    this.searchInput = inputElement.value
  }
}
