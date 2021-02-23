import { HttpClientModule } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';

import { InvoiceDataService } from './invoice-data.service';

describe('InvoiceDataService', () => {
  let service: InvoiceDataService;
  
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule],
      providers: [InvoiceDataService]
    });
    service = TestBed.get(InvoiceDataService);
  });

  it('should get the list of invoices', () => {
    service.getInvoices(null).subscribe(invoices => {
      expect(invoices.length).toBeGreaterThan(0);
      expect().nothing();
    });
  });

});
