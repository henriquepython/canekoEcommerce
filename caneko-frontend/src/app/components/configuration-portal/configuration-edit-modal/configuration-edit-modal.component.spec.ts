import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfigurationEditModalComponent } from './configuration-edit-modal.component';

describe('ConfigurationEditModalComponent', () => {
  let component: ConfigurationEditModalComponent;
  let fixture: ComponentFixture<ConfigurationEditModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ConfigurationEditModalComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ConfigurationEditModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
