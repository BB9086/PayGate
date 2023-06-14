import { Injectable } from "@angular/core";
import { CardPaymentResponse } from "../models/CardPaymentResponse.model";
import { NewCardModel } from "../models/NewCardModel.model";
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { environment } from "src/environments/environment";

@Injectable()
export class PaymentService {

  queryResultString:string;
    constructor(
      private httpClient: HttpClient
    ) {

        
     }


  
    tokenizeCard(model: NewCardModel) {
      return this.httpClient.post<CardPaymentResponse>(`${environment.API_URL}/api/payment`, model);
    }
    queryTransaction(payRequestId: string) {
      return this.httpClient.get<string>(`${environment.API_URL}/api/payment/query/${payRequestId}`);
    }
    getVaultedCard(vaultId: string) {
      return this.httpClient.get(`${environment.API_URL}/api/payment/${vaultId}`);
    }

    sendPostRequest(parameter: string) {
        return this.httpClient.post<string>(`${environment.MYAPI_URL}/api/notify`, parameter);
      }
    
  }
  