import { TestBed } from '@angular/core/testing';

import { CampService } from './camp.service';

describe('CampService', () => {
  let service: CampService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CampService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
