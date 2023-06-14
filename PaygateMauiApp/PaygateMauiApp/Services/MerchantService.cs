using PaygateMauiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PaygateMauiApp.Services
{
    public class MerchantService:IMerchantService
    {
        HttpClient httpClient;
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        private readonly string baseAddress;
        private readonly string url;
        private readonly IConnectivity connectivity;
        public MerchantService(HttpClient httpClient, IConnectivity connectivity) {

            this.httpClient= httpClient;
            this.connectivity= connectivity;
            //baseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.0.164/merchantApiPaygate/api/payment" : "http://192.168.0.164/merchantApiPaygate/api/payment";
            baseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "https://merchantapipaygate20230531092425.azurewebsites.net/api/payment" : "https://merchantapipaygate20230531092425.azurewebsites.net/api/payment";
            this._jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy
           = JsonNamingPolicy.CamelCase
            };
        }

        public async Task PostNewCart(NewCardModel model)
        {
            if(connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("Error", "No internet access! Check your internet status.", "OK");
            }
            try
            {
                NewCard card = new NewCard
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    CardNumber = (long)Convert.ToDecimal(model.CardNumber),
                    CardExpiry = (uint)Convert.ToInt32(model.CardExpiry),
                    Cvv = (uint)Convert.ToInt32(model.Cvv),
                    Vault= model.Vault, 
                    Amount=Convert.ToDecimal(model.Amount)
                };
                string jsonString = JsonSerializer.Serialize<NewCard>(card, _jsonSerializerOptions);
                //moze da se ubaci u httpcontent jer se inherit iz httpcontenta:
                StringContent strContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await this.httpClient.PostAsync(this.baseAddress, strContent);
                if (response.IsSuccessStatusCode)
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                   
                    
                    CardPaymentResponse cardResponse= JsonSerializer.Deserialize<CardPaymentResponse>(stringResponse, _jsonSerializerOptions);

                    if (!cardResponse.Completed)
                    {
                        await Shell.Current.GoToAsync(nameof(Secured3Dpage), true, new Dictionary<string, object>
                        {
                            {"CardResponseModel",cardResponse }
                        });
                        
                    }
                    else
                    {
                        await Shell.Current.GoToAsync(nameof(ResultPage), true, new Dictionary<string, object>
                        {
                            {"CardResponseModel",cardResponse }
                        });
                    }
                    


                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "Can not execute PostAsync!", "OK");

                }
            }
            catch(Exception ex) {

                await Shell.Current.DisplayAlert("Error", "Exception message: " + ex.Message, "OK");

            }
        }
    }
}
