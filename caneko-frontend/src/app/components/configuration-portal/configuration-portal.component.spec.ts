import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfigurationPortalComponent } from './configuration-portal.component';

describe('ConfigurationPortalComponent', () => {
  let component: ConfigurationPortalComponent;
  let fixture: ComponentFixture<ConfigurationPortalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ConfigurationPortalComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ConfigurationPortalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
