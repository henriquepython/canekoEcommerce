import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InitBackofficeComponent } from './init-backoffice.component';

describe('InitBackofficeComponent', () => {
  let component: InitBackofficeComponent;
  let fixture: ComponentFixture<InitBackofficeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InitBackofficeComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InitBackofficeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
