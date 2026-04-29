import { TestBed } from '@angular/core/testing';

import { InvestmentCalculatorService } from './investment-calculator.service';

describe('InvestmentCalculatorService', () => {
  let service: InvestmentCalculatorService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(InvestmentCalculatorService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
