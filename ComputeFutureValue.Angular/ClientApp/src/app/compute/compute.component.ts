import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { first } from 'rxjs/operators';
import { AlertService } from '../services/alert.service';
import { ComputeDataService } from '../services/compute-data.service';
import { Invoice } from '../view-models/invoice-history';
import es from '@angular/common/locales/es';
import { registerLocaleData } from '@angular/common';

@Component({
  selector: 'app-compute',
  templateUrl: './compute.component.html',
  styleUrls: ['./compute.component.css']
})
export class ComputeComponent implements OnInit {

  invoiceForm: FormGroup;
  loading = false;
  submitted = false;

  invoice: Invoice = {
    presentValue: 0,
    lowerBoundInterestRate: 0,
    upperBoundInterestRate: 0,
    incrementalRate: 0,
    maturity: 0,
    futureValue: 0
  };


  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private computeService: ComputeDataService,
    private alertService: AlertService
  ) { }


  ngOnInit() {
    registerLocaleData(es);
    this.invoiceForm = this.formBuilder.group({
      presentValue: ['', Validators.required],
      lowerBoundInterestRate: ['', Validators.required],
      upperBoundInterestRate: ['', Validators.required],
      incrementalRate: ['', Validators.required],
      maturity: ['', Validators.required],
    });
  }

  get f() { return this.invoiceForm.controls; }


  onComputeFutureValue() {
    this.submitted = true;

    this.alertService.clear();

    if (this.invoiceForm.invalid) {
      return;
    }

    this.invoice.presentValue = +this.invoiceForm.get('presentValue').value;
    this.invoice.lowerBoundInterestRate = +this.invoiceForm.get('lowerBoundInterestRate').value;
    this.invoice.upperBoundInterestRate = +this.invoiceForm.get('upperBoundInterestRate').value;
    this.invoice.incrementalRate = +this.invoiceForm.get('incrementalRate').value;
    this.invoice.maturity = +this.invoiceForm.get('maturity').value;

    this.loading = true;
    this.computeService.computeFutureValue(this.invoice)
      .pipe(first())
      .subscribe(
        data => {
          this.alertService.success('Successfully compute the future invoice', { keepAfterRouteChange: true });
          this.router.navigate([''], { relativeTo: this.route });
        },
        error => {
          this.alertService.error(error);
          this.loading = false;
        });
  }

  cancelComputation() {
    this.router.navigate(['']);
  }

}
