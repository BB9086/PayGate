# 3D Secure Online Payments with PayGate – .NET MAUI, Angular 2, ASP.NET Core MVC, ASP.NET Core Web API, SignalR


**About this app:**  In order to process payments on credit card via the PayGate system (https://www.paygate.co.za), two client applications are created, one in .NET MAUI (PaygateMauiApp), and another in Angular framework (Paygate_AngularApp). 
These applications perform the same role of testing credit card payments with test credentials provided by PayGate itself. Customer enters card details (card number, card expiry date, cvv, amount) on the merchant’s web site 
(MerchantApi_Paygate - web api hosted on Microsoft Azure) that communicates with PayGate. Using PayGate test credentials, the customer can make a direct payment
via MasterCard, or payment via 3D Secure Redirect Required Page (Visa card). 

If 3D Secure authentication is required, PayGate processes the transaction to the acquiring bank and sends a payment notification message 
to the SignalRPaygateService (hosted on Microsoft Azure). This url is specified in the NotifyUrl attribute in the original payment request message. 
The NotifyUrl must return the value ‘OK’ to indicate that the post was received. The URL specified in the ReturnUrl attribute 
in the original payment request message is where the customer’s browser will be redirected once the transaction is complete. 

For more info, please visit: https://docs.paygate.co.za/#payhost

**PayGate test credentials:**

https://docs.paygate.co.za/#testing-2 <br />

**Steps in the payment request process:**

![cardpayment_process_flow](https://github.com/BB9086/PayGate/assets/118169200/a3e388dc-c2fe-4c86-b95f-d42fad4d3d68)

1. Customer enters card details on the merchant’s web site / system.
2. Merchant sends a payment request message to PayHost. The following steps are only required if a “Secure” message is received in step 3.
3. The merchant is required to redirect the customer’s internet browser to PayGate’s MPI. 
4. PayGate re-directs the customer to the appropriate issuing bank 3D Secure authentication page. Customers will be required to enter a PIN code / password known only to themselves and their bank inorder to authenticate them.
5. The issuing bank 3D Secure authentication page will redirect the customer’s browser back to PayGate.
6. If the message received from the issuing bank (in step 6) is valid, then PayGate processes the transaction to the acquiring bank and sends a payment notification message to the merchant (if the merchant has specified a NotifyUrl).
7. The Merchant website responds with the word ‘OK’ to PayGate.
8. PayGate redirects the customer’s browser back to the merchant’s website so that the merchant can complete the order process. The following step follows on from step 3.
9. The transaction is processed to the acquiring bank and the result is returned.

## Web app - Angular
#### Payment request / Payment result
![anguar app](https://github.com/BB9086/PayGate/assets/118169200/eb8c12ea-d2e0-45a4-aed3-ea31f7516278)

## Mobile app - .NET MAUI
#### Steps in the payment request process - Mastercard
###### Card Details
<kbd><img src="https://github.com/BB9086/PayGate/assets/118169200/d6b91710-01c0-4d4d-ab92-f0d9749e4081.jpg" alt="alt text" width="40%" height="40%"></kbd><br />
###### Payment is approved
<kbd><img src="https://github.com/BB9086/PayGate/assets/118169200/2f34043b-5991-4123-9d34-dba1af89ee5b.jpg" alt="alt text" width="40%" height="40%"></kbd><br />
#### Steps in the payment request process - Visa card
###### Card Details
<kbd><img src="https://github.com/BB9086/PayGate/assets/118169200/fb60986e-2906-4e8a-8442-2eb1b29fef86.jpg" alt="alt text" width="40%" height="40%"></kbd><br />
###### 3D Secure authentication page
<kbd><img src="https://github.com/BB9086/PayGate/assets/118169200/335e724e-0364-4b02-9ee1-fff8d029364f.jpg" alt="alt text" width="40%" height="40%"></kbd><br />
###### Payment is approved 
<kbd><img src="https://github.com/BB9086/PayGate/assets/118169200/700de3a8-1410-41f0-bc5f-d04ef9fcb9a3.jpg" alt="alt text" width="40%" height="40%"></kbd><br />

