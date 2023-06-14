using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaygateMauiApp.Models
{
    public class NewCard
    {
        
        public string FirstName { get; set; }

      
        public string LastName { get; set; }

        
        public string Email { get; set; }

       
        public long CardNumber { get; set; }

       
        public uint CardExpiry { get; set; }

       
        public uint Cvv { get; set; }
        public bool Vault { get; set; }

      
        public decimal Amount { get; set; }
    }
}
