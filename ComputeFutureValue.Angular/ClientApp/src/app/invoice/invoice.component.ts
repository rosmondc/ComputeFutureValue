import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { InvoiceDataService } from '../services/invoice-data.service';
import { Invoice } from '../view-models/invoice-history';

@Component({
  selector: 'app-invoice',
  templateUrl: './invoice.component.html',
  styleUrls: ['./invoice.component.css']
})
export class InvoiceComponent implements OnInit {

  invoices = [];
  stringValue: string;
  displayedColumns = ['presentValue', 'lowerBoundInterestRate', 'upperBoundInterestRate', 'incrementalRate', 'maturity', 'futureValue'];
  dataSource: MatTableDataSource<Invoice>; 

  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;

  constructor(private invoiceService: InvoiceDataService) { }

  ngOnInit() {
    this.invoiceService.getInvoices("").subscribe(_invoices => {
      this.dataSource = new MatTableDataSource(_invoices);
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;
    });
  }

  applyFilter(filterValue: string) {
    filterValue = filterValue.trim(); // Remove whitespace
    filterValue = filterValue.toLowerCase(); // Datasource defaults to lowercase matches
    this.dataSource.filter = filterValue;
  }

}
