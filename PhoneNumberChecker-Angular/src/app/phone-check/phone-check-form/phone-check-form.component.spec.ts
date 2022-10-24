import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PhoneCheckFormComponent } from './phone-check-form.component';

describe('PhoneCheckFormComponent', () => {
  let component: PhoneCheckFormComponent;
  let fixture: ComponentFixture<PhoneCheckFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PhoneCheckFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PhoneCheckFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
