using PaygateMauiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaygateMauiApp.Services
{
    public interface IMerchantService
    {
        Task PostNewCart(NewCardModel model);
    }
}
