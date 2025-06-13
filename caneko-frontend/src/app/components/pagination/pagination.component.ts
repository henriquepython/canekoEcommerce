import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-pagination',
  standalone: true,
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.scss']
})
export class PaginationComponent {
  @Input() totalPages = 1;
  @Input() currentPage = 1;
  @Output() pageChange = new EventEmitter<number>();

  get pages(): (number | string)[] {
    const pagesToShow = [];

    if (this.totalPages <= 5) {
      for (let i = 1; i <= this.totalPages; i++) {
        pagesToShow.push(i);
      }
    } else {
      pagesToShow.push(1);

      if (this.currentPage > 3) pagesToShow.push('...');

      const start = Math.max(2, this.currentPage - 1);
      const end = Math.min(this.totalPages - 1, this.currentPage + 1);

      for (let i = start; i <= end; i++) {
        pagesToShow.push(i);
      }

      if (this.currentPage < this.totalPages - 2) pagesToShow.push('...');

      pagesToShow.push(this.totalPages);
    }

    return pagesToShow;
  }

  mudarPagina(pagina: number | string) {
    if (typeof pagina === 'number' && pagina !== this.currentPage) {
      this.pageChange.emit(pagina);
    }
  }
}