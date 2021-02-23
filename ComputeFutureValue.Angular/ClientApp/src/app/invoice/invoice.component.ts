import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { InvoiceDataService } from '../services/invoice-data.service';
import { InvoiceHistory } from '../view-models/invoice-history';

@Component({
  selector: 'app-invoice',
  templateUrl: './invoice.component.html',
  styleUrls: ['./invoice.component.css']
})
export class InvoiceComponent implements OnInit {

  invoices = [];
  stringValue: string;
  displayedColumns = ['presentValue', 'lowerBoundInterestRate', 'upperBoundInterestRate', 'incrementalRate', 'maturity', 'futureValue'];
  dataSource: MatTableDataSource<InvoiceHistory>; 

  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;


  constructor(private invoiceService: InvoiceDataService, private route: ActivatedRoute,
    private router: Router ) { }


  ngOnInit() {
    this.invoiceService.getInvoices("").subscribe(_invoices => {
      this.dataSource = new MatTableDataSource(_invoices);
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;
    });

  }

}
