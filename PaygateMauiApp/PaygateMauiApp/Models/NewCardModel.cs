using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaygateMauiApp.Models
{
    public class NewCardModel
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string CardNumber { get; set; }
        public string CardExpiry { get; set; }
        public string Cvv { get; set; }
        public bool Vault { get; set; }
        public string Amount { get; set; }

    }
}
