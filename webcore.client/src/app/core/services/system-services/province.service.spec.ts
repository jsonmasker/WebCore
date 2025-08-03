import { TestBed } from '@angular/core/testing';

import { ProvinceService } from './province.service';

describe('ProvinceService', () => {
  let service: ProvinceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProvinceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
