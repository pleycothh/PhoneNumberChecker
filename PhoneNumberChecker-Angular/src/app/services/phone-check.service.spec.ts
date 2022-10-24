import { TestBed } from '@angular/core/testing';

import { PhoneCheckService } from './phone-check.service';

describe('PhoneCheckService', () => {
  let service: PhoneCheckService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PhoneCheckService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
