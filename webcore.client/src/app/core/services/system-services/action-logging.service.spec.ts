import { TestBed } from '@angular/core/testing';

import { ActionLoggingService } from './action-logging.service';

describe('ActionLoggingService', () => {
  let service: ActionLoggingService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ActionLoggingService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
