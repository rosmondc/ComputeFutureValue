import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { first } from 'rxjs/operators';
import { InvoiceDataService } from '../services/invoice-data.service';

@Component({
  selector: 'app-invoice',
  templateUrl: './invoice.component.html',
  styleUrls: ['./invoice.component.css']
})
export class InvoiceComponent implements OnInit {

  invoices = [];
  stringValue: string;

  constructor(private invoiceService: InvoiceDataService, private route: ActivatedRoute,
    private router: Router ) { }

  ngOnInit() {
    this.invoiceService.getInvoices("")
      .pipe()
      .subscribe(_ => this.invoices = _);


    this.stringValue = "mon castillo";
    console.log(`invoices : ${this.invoices}`);
  }

}
