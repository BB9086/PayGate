import { Component, OnInit } from '@angular/core';
import { PaymentService } from '../services/payment.services';
import { DomSanitizer } from '@angular/platform-browser';
import { NgForm } from '@angular/forms';
import { NewCardModel } from '../models/NewCardModel.model';
import { SignalrService } from '../services/signalr.services';

@Component({
  selector: 'app-pay',
  templateUrl: './pay.component.html',
  styleUrls: ['./pay.component.css']
})
export class PayComponent implements OnInit {

  model: NewCardModel = {
    lastName: null,
    firstName: null,
    email: null,
    cardExpiry: null,
    cardNumber: null,
    cvv: null,
    vault: null,
    amount: null
  };
  Secure3DHTML: any;
  payRequestId: string;
  paymentResult: any;
  isLoading = false;


  constructor(public paySvc: PaymentService,
    private sanitizer: DomSanitizer, private signalRService: SignalrService) {
    signalRService.startConnection();
  }

  ngOnInit(): void {
  }


  makePayment(form: NgForm) {
    if (form.submitted && form.valid) {
      // form.value == this.model
      this.isLoading = true;
      this.paySvc.tokenizeCard(form.value).toPromise()
        .then((res) => {
          /**
           * {"Status":
           * {
           * "TransactionId":"292899202",
           * "Reference":"bd41987e-0127-47d4-8dea-217da036d819",
           * "AcquirerCode":"00",
           * "StatusName":"Completed",
           * "AuthCode":"M95HBZ",
           * "PayRequestId":"9EB11432-A807-4C78-A73C-959731F67EEF",
           * "VaultId":"3a7615eb-2af6-4a29-98cd-dbc67c0e4fb2",
           * "PayVaultData":
           *      [
           *      {"name":"cardNumber","value":"xxxxxxxxxxxx0015"},
           *      {"name":"expDate","value":"112023"}
           *      ],
           * "TransactionStatusCode":"1",
           * "TransactionStatusDescription":"Approved",
           * "ResultCode":"990017",
           * "ResultDescription":"Auth Done",
           * "Currency":"ZAR",
           * "Amount":"200","RiskIndicator":"AP",
           * "PaymentType":{"Method":"CC","Detail":"MasterCard"}}
           * }
           */
          this.isLoading = false;
          if (res.completed) {
            res.response = JSON.parse(res.response);
            this.paymentResult = res;
          } else {
            // probably 3D secure
           
            console.log(res.secure3DHtml);
            this.Secure3DHTML = this.sanitizer.bypassSecurityTrustResourceUrl(`data:text/html,${res.secure3DHtml}`);
            console.log(this.Secure3DHTML);
            this.payRequestId = res.payRequestId;
            console.log("Request id:");
            console.log(this.payRequestId);
            //this.connectSignalRApp(res.payRequestId);
          }
        }).catch(err => {
          console.log(err);
        });
    }
  }

  // connectToSocket(payId: string) {
  //   this.socket = this.paySvc.openSocketConnection(payId);
  //   this.socket.on('message', (e: any) => {
  //     console.log('connected to socket');
  //     // this.socketMessages = e;
  //   });
  //   this.socket.on('joined', (content: any) => {
  //     console.log(content);
  //     // this.socketMessages = content;
  //   });
  //   this.socket.on('complete', async (payload: any) => {
  //     this.Secure3DHTML = null;
  //     this.completeFollowUp();
  //   });
  // }

  // completeFollowUp() {
  //   this.paySvc.queryTransaction(this.payRequestId).toPromise()
  //       .then(async (res) => {
  //         this.paymentResult = res;
  //       }, async error => {
  //         console.error(error);
  //       });
  // }

}
