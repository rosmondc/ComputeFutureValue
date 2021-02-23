import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Invoice } from '../view-models/invoice-history';
import { API_URL, httpOptions } from '../helpers/constants';


@Injectable({
  providedIn: 'root'
})

export class InvoiceDataService {

  constructor(private http: HttpClient) { }

  getInvoices(sortOrder: string): Observable<Invoice[]> {
    const url = `${API_URL}/invoice?sortOrder=${sortOrder}`;

    return this.http.get<Invoice[]>(url, httpOptions).pipe(
      catchError(err => {
        console.log('Error when trying to get invoice list.', err);
        if (err.status === 401)

          return throwError(err);
      }));
  }

}
