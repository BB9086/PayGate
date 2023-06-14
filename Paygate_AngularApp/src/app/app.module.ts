import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {FormsModule} from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PayComponent } from './pay/pay.component';
import { PaymentService } from './services/payment.services'; 
import { SignalrService } from './services/signalr.services';



@NgModule({
  declarations: [
    AppComponent,
    PayComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [PaymentService, SignalrService],
  bootstrap: [AppComponent]
})
export class AppModule { }
