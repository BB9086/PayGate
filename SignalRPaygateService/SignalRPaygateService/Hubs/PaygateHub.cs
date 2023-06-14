using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRPaygateService.Hubs
{
    public class PaygateHub : Hub<IPaygateHub>
    {
        public async Task SendOffersToUser(string message)
        {
            await Clients.All.SendOffersToUser(message);
        }

    }
}
