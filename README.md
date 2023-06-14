# 3D Secure Online Payments with PayGate – .NET MAUI, Angular 2, ASP.NET Core MVC, ASP.NET Core Web API, SignalR


**About this app:**  In order to process payments on credit card via the PayGate system (https://www.paygate.co.za), two client applications are created, one in .NET MAUI, and another in Angular framework. 
These applications perform the same role of testing credit card payments with test credentials provided by PayGate itself. Customer enters card details (card number, card expiry date, cvv, amount) on the merchant’s web site 
(web api hosted on Microsoft Azure) that communicates with PayGate. Using PayGate test credentials, the customer can make a direct payment
via MasterCard, or payment via 3D Secure Redirect Required Page (Visa card). If 3D Secure authentication is required, PayGate processes the transaction to the acquiring bank and sends a payment notification message 
to the signalr website url hosted on Microsoft Azure. This url is specified in the NotifyUrl attribute in the original payment request message. 
The NotifyUrl must return the value ‘OK’ to indicate that the post was received. The URL specified in the ReturnUrl (https://signalrpaygateservice20230424095904.azurewebsites.net/api/notify/getInfo) attribute 
in the original payment request message is where the customer’s browser will be redirected once the transaction is complete. 
For more info, please visit: https://docs.paygate.co.za/#payhost

**PayGate test credentials:**

https://docs.paygate.co.za/#testing-2 <br />

## Phone screenshots

###### Login Page
<img src="https://user-images.githubusercontent.com/118169200/204515132-c6c3cc78-529f-4ae6-a5c6-a043c2d13c19.jpg" alt="alt text" width="40%" height="40%">
