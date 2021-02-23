import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { InvoiceComponent } from './invoice/invoice.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { ComputeComponent } from './compute/compute.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,    
    InvoiceComponent,
    ComputeComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    MatTableModule,
    MatSortModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([    
      { path: '', component: InvoiceComponent, pathMatch: 'full' },
      { path: 'compute', component: ComputeComponent },
], { relativeLinkResolution: 'legacy' }),
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
