import { HttpClientModule } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';
import { Invoice } from '../view-models/invoice-history';

import { ComputeDataService } from './compute-data.service';

describe('ComputeDataService', () => {
  let service: ComputeDataService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule],
      providers: [ComputeDataService]
    });
    service = TestBed.get(ComputeDataService);
  });


  it('should get the computed future value', () => {
    const invoice: Invoice = {
      presentValue: 400.75,
      lowerBoundInterestRate: 15,
      upperBoundInterestRate: 60,
      incrementalRate: 10,
      maturity: 5,
      futureValue: 0
    };

    service.computeFutureValue(invoice).subscribe(_compute => {
      expect(_compute).toBeGreaterThan(0)
      expect(_compute).toEqual(1747.893041);
      expect().nothing();
    });

  });

});
