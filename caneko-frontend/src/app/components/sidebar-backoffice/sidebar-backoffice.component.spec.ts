import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SidebarBackofficeComponent } from './sidebar-backoffice.component';

describe('SidebarBackofficeComponent', () => {
  let component: SidebarBackofficeComponent;
  let fixture: ComponentFixture<SidebarBackofficeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SidebarBackofficeComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SidebarBackofficeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
