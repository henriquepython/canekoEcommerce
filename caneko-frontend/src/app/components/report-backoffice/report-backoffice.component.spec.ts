import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReportBackofficeComponent } from './report-backoffice.component';

describe('ReportBackofficeComponent', () => {
  let component: ReportBackofficeComponent;
  let fixture: ComponentFixture<ReportBackofficeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ReportBackofficeComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ReportBackofficeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
