using CommunityToolkit.Mvvm.ComponentModel;
using PaygateMauiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaygateMauiApp.ViewModels
{
    [QueryProperty("CardResponseModel", "CardResponseModel")]
    public partial class Secured3DViewModel:ObservableObject
    {
        public Secured3DViewModel()
        {

        }

        [ObservableProperty]
        CardPaymentResponse cardResponseModel;
    }
}
