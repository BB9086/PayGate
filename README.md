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
![1](https://github.com/BB9086/PayGate/assets/118169200/492f6cd4-d517-42ec-bdb0-994ca5a846f9)


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
![2](https://github.com/BB9086/PayGate/assets/118169200/9febf1df-5c07-4b56-864e-1bf2ed31242a)

## Mobile app - .NET MAUI
#### Steps in the payment request process (without 3D Secure authentication page) - Mastercard
###### Card Details
<kbd><img src="https://github.com/BB9086/PayGate/assets/118169200/31b361e9-04cf-437c-9852-beb76d788a85.jpg" alt="alt text" width="40%" height="40%"></kbd><br />
###### Payment is approved
<kbd><img src="https://github.com/BB9086/PayGate/assets/118169200/94535aa5-75c4-4f9e-9429-977601041083.jpg" alt="alt text" width="40%" height="40%"></kbd><br />
#### Steps in the payment request process (with 3D Secure authentication page) - Visa card
###### Card Details
<kbd><img src="https://github.com/BB9086/PayGate/assets/118169200/a574261b-fcbd-4052-82f9-c9da35ffb7c4.jpg" alt="alt text" width="40%" height="40%"></kbd><br />
###### 3D Secure authentication page
<kbd><img src="https://github.com/BB9086/PayGate/assets/118169200/7ba4f595-3bd5-4ab9-9662-d3833a08849e.jpg" alt="alt text" width="40%" height="40%"></kbd><br />
###### Payment is approved 
<kbd><img src="https://github.com/BB9086/PayGate/assets/118169200/5f629d75-161c-4100-98d8-dcb80fd21ad2.jpg" alt="alt text" width="40%" height="40%"></kbd><br />

