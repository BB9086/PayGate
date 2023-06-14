using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRPaygateService.Hubs;
using SignalRPaygateService.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SignalRPaygateService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotifyController : ControllerBase
    {
        private IHubContext<PaygateHub, IPaygateHub> messageHub;

        public NotifyController(IHubContext<PaygateHub, IPaygateHub> messageHub)
        {
            this.messageHub = messageHub;
        }

        [HttpPost]
        public async Task<string> Post()
        {
            PaygateHub hub = new PaygateHub();
            Dictionary<string, string> result = new Dictionary<string, string>();
            string str;
            XmlModel model = new XmlModel();

            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                string rawValue = await reader.ReadToEndAsync();
                str = rawValue;
            }

            string[] valuePairs = str.Split('&');
            foreach (string valuePair in valuePairs)
            {
                
                string[] values = valuePair.Split('=');
                if (values[0] == "PAY_REQUEST_ID")
                {
                    model.PAY_REQUEST_ID = values[1];
                }
                else if (values[0] == "TRANSACTION_STATUS")
                {
                    model.TRANSACTION_STATUS = values[1];
                }
                else if (values[0] == "CHECKSUM")
                {
                    model.CHECKSUM = values[1];
                }

              

            }

            await messageHub.Clients.All.SendOffersToUser(str);
            return "Post!Offers sent successfully to all users!";
        }

        [HttpPost]
        [Route("getInfo")]
        public async Task<ContentResult> Get()
        {
            //await messageHub.Clients.All.SendOffersToUser("GET");

            PaygateHub hub = new PaygateHub();
            Dictionary<string, string> result = new Dictionary<string, string>();
            string str;
            XmlModel model = new XmlModel();

            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                string rawValue = await reader.ReadToEndAsync();
                str = rawValue;
            }

            string[] valuePairs = str.Split('&');
            foreach (string valuePair in valuePairs)
            {
                string[] values = valuePair.Split('=');
                if (values[0] == "PAY_REQUEST_ID")
                {
                    model.PAY_REQUEST_ID = values[1];
                }
                else if (values[0] == "TRANSACTION_STATUS")
                {
                    model.TRANSACTION_STATUS = values[1];
                }
                else if (values[0] == "CHECKSUM")
                {
                    model.CHECKSUM = values[1];
                }
               

            }

            HttpClient client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });
            HttpResponseMessage response = client.GetAsync("https://merchantapipaygate20230531092425.azurewebsites.net/api/payment/query/" + model.PAY_REQUEST_ID).Result;

            response.EnsureSuccessStatusCode();
            string result1 = response.Content.ReadAsStringAsync().Result;
            var color = result1.Split("TransactionStatusDescription")[1].Split(",")[0].Split(": ")[1].ToString().Replace("\"", String.Empty) == "Approved" ? "green" : "red";

            await messageHub.Clients.All.SendOffersToUser("Get!!!");
            //return "GET but Post !Offers sent successfully to all users!: " + model.TRANSACTION_STATUS;
            return new ContentResult
            {
                ContentType = "text/html",
                Content = "<h4 style='color:green'>Transaction with Request Id: 577F267A-3D3D-440E-AABB-880606D7DA0F</h4><p style='color:green'>Status: " + result1.Split("StatusName")[1].Split(",")[0].Split(": ")[1].ToString().Replace("\"", String.Empty) + "</p>" +
                "<p style='color:" + color + "'>Status Description: " + result1.Split("TransactionStatusDescription")[1].Split(",")[0].Split(": ")[1].ToString().Replace("\"", String.Empty) + "</p>"

            };



        }



        [HttpGet]

        public string GetTest()
        {
            //await messageHub.Clients.All.SendOffersToUser("GET");

            //var pp = Microsoft.AspNetCore.Http.Extensions.UriHelper.GetDisplayUrl(this.Request);
            //var ppappa = Microsoft.AspNetCore.Http.Extensions.UriHelper.GetEncodedUrl(this.Request);

            //var x = HttpContext.Request.Path;
            //var y = HttpContext.Request.Host;
            //var mmm = HttpContext.Request.Headers;

            return "GET!: ";
        }



    }
}

