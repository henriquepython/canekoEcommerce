import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderBackofficeComponent } from './order-backoffice.component';

describe('OrderBackofficeComponent', () => {
  let component: OrderBackofficeComponent;
  let fixture: ComponentFixture<OrderBackofficeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [OrderBackofficeComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OrderBackofficeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
