import { TestBed } from '@angular/core/testing';

import { I18nPtBrService } from './i18nPtBr.service';

describe('I18nPtBrServiceService', () => {
  let service: I18nPtBrService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(I18nPtBrService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
