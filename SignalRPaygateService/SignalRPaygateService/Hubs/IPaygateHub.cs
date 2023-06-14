using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRPaygateService.Hubs
{
    public interface IPaygateHub
    {
        Task SendOffersToUser(string message);
    }
}
