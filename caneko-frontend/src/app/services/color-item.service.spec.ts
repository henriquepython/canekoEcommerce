import { TestBed } from '@angular/core/testing';

import { ColorItemService } from './color-item.service';

describe('ColorItemService', () => {
  let service: ColorItemService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ColorItemService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
