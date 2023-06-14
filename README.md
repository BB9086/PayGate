# 3D Secure Online Payments with PayGate – .NET MAUI, Angular 2, ASP.NET Core MVC, ASP.NET Core Web API, SignalR


**About this app:**  In order to process payments on credit card via the PayGate system (https://www.paygate.co.za), two client applications are created, one in .NET MAUI, and another in Angular framework. 
These applications perform the same role of testing credit card payments with test credentials provided by PayGate itself. Customer enters card details (card number, card expiry date, cvv, amount) on the merchant’s web site 
(web api hosted on Microsoft Azure) that communicates with PayGate. Using PayGate test credentials, the customer can make a direct payment
via MasterCard, or payment via 3D Secure Redirect Required Page (Visa card). 

If 3D Secure authentication is required, PayGate processes the transaction to the acquiring bank and sends a payment notification message 
to the SignalRPaygateService (signalr website url hosted on Microsoft Azure). This url is specified in the NotifyUrl attribute in the original payment request message. 
The NotifyUrl must return the value ‘OK’ to indicate that the post was received. The URL specified in the ReturnUrl (https://signalrpaygateservice20230424095904.azurewebsites.net/api/notify/getInfo) attribute 
in the original payment request message is where the customer’s browser will be redirected once the transaction is complete. 

For more info, please visit: https://docs.paygate.co.za/#payhost

**PayGate test credentials:**

https://docs.paygate.co.za/#testing-2 <br />

**Steps in the payment request process:**

![cardpayment_process_flow](https://github.com/BB9086/PayGate/assets/118169200/a3e388dc-c2fe-4c86-b95f-d42fad4d3d68)

1. Customer enters card details on the merchant’s web site / system.
2. Merchant sends a payment request message to PayHost. The following steps are only required if a “Secure” message is received in step 3.
3. The merchant is required to redirect the customer’s internet browser to PayGate’s MPI. (Refer to “3DSecure using PayGate’s MPI” for more detail).
4. PayGate re-directs the customer to the appropriate issuing bank 3D Secure authentication page.Customers will be required to enter a PIN code / password known only to themselves and their bank inorder to authenticate them.
5. The issuing bank 3D Secure authentication page will redirect the customer’s browser back to PayGate.
6. If the message received from the issuing bank (in step 6) is valid, then PayGate processes the transaction to the acquiring bank and sends a payment notification message to the merchant (if the merchant hasspecified a NotifyUrl)..
7. The Merchant website responds with the word ‘OK’ to PayGate.
8. PayGate redirects the customer’s browser back to the merchant’s website so that the merchant can complete the order process. (Refer to “Redirect to website” for more detail). The following step follows on from step 3.
9. The transaction is processed to the acquiring bank and the result is returned.

## Web app - Angular
#### Payment is approved
![anguar app](https://github.com/BB9086/PayGate/assets/118169200/eb8c12ea-d2e0-45a4-aed3-ea31f7516278)

## Mobile app - .NET MAUI

###### Login Page
<img src="https://user-images.githubusercontent.com/118169200/204515132-c6c3cc78-529f-4ae6-a5c6-a043c2d13c19.jpg" alt="alt text" width="40%" height="40%">
