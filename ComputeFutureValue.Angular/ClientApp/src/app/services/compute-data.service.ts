import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { API_URL, httpOptions } from '../helpers/constants';
import { Invoice } from '../view-models/invoice-history';

@Injectable({
  providedIn: 'root'
})
export class ComputeDataService {

  constructor(private http: HttpClient) { }

  computeFutureValue(invoice: Invoice): Observable<number> {
    const url = `${API_URL}/invoice/compute`;
    return this.http.post<number>(url, invoice, httpOptions).pipe(
      catchError(err => {
        console.log('Error when trying to compute future value.', err);
        return throwError(err);
      })
    );
  }

  
}
