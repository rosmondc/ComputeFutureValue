import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { InvoiceHistory } from '../view-models/invoice-history';


const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class InvoiceDataService {

  apiUrl = 'https://localhost:5001/api/invoice';
  constructor(private http: HttpClient) { }

  getInvoices(sortOrder: string): Observable<InvoiceHistory[]> {
    const url = `${this.apiUrl}?sortOrder=${sortOrder}`;

    return this.http.get<InvoiceHistory[]>(url, httpOptions).pipe(
      catchError(err => {
        console.log('Error when trying to get invoice list.', err);
        if (err.status === 401)

          return throwError(err);
      }));
  }

}
