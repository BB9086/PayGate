using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PaygateMauiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaygateMauiApp.ViewModels
{
    public partial class MainPageViewModel:ObservableObject
    {
        public MainPageViewModel()
        {
            CardModel = new NewCardModel();
        }

        [ObservableProperty]
        NewCardModel cardModel;

        [RelayCommand]
        async Task PayAsync(NewCardModel model)
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
