import { Injectable } from "@angular/core";
import * as signalR from "@microsoft/signalr";
import { PaymentService } from "./payment.services";

@Injectable()
export class SignalrService {

    hubConnection:signalR.HubConnection;
    constructor(private paymentService:PaymentService) {

      
    }

    startConnection=()=>{
        this.hubConnection=new signalR.HubConnectionBuilder().withUrl("https://signalrpaygateservice20230424095904.azurewebsites.net/paygate",{
            transport:signalR.HttpTransportType.LongPolling
        }).build();

        this.hubConnection.start().then(()=>{
            console.log("SignalR connected!");
        }).catch((err:any)=>console.log('Error while starting connection: '+err));

        this.hubConnection.on("SendOffersToUser",(message:string)=>{
            console.log(message);
            // this.paymentService.queryTransaction(message).subscribe((x:string)=>{
            //     this.paymentService.queryResultString=x;

            // })

            

            
        });


    }

    // sendMessage(){
    //     this.hubConnection.invoke("SendMessage")
    //     .catch((err:any)=>console.log(err));
    // }

    // receivedMessage(){
    //     this.hubConnection.on("MessageReceived",(message:string)=>{
    //         console.log(message);
            
    //     });

    // }

}