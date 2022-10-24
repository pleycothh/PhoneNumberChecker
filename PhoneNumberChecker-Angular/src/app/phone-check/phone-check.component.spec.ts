import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PhoneCheckComponent } from './phone-check.component';

describe('PhoneCheckComponent', () => {
  let component: PhoneCheckComponent;
  let fixture: ComponentFixture<PhoneCheckComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PhoneCheckComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PhoneCheckComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
