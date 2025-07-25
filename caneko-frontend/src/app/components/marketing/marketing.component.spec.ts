import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MarketingComponent } from './marketing.component';

describe('EditItemComponent', () => {
  let component: MarketingComponent;
  let fixture: ComponentFixture<MarketingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MarketingComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MarketingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
