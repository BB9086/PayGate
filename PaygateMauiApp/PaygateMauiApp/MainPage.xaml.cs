using Microsoft.Maui;
using Microsoft.Maui.Controls;
using PaygateMauiApp.Models;
using PaygateMauiApp.Services;
using PaygateMauiApp.ViewModels;

namespace PaygateMauiApp;

public partial class MainPage : ContentPage
{
	private bool formValidation;
    IMerchantService service;
    public MainPage(MainPageViewModel mpvm, IMerchantService service)
	{
		InitializeComponent();
        this.service = service;
		BindingContext= mpvm;	
	}

    private void cvvValidator_TextChanged(object sender, TextChangedEventArgs e)
    {

		if (cvvValidator.IsNotValid)
		{
            foreach (var error in cvvValidator.Errors)
            {
        if((error.ToString()== "Only numbers allowed" || error.ToString()== "Only 3 digits allowed") && cvvEntry.Text!="")
                    
            DisplayAlert("Error", "" + error.ToString(), "OK");
               
            }

        }

    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
         
        formValidation = false;
        activityIndicator.IsVisible = true;
        activityIndicator.IsRunning = true;

        CounterBtn.IsEnabled = false;
        // assuming your Model class is "Student"
        var border = sender as Button;
       var item= (NewCardModel)border.CommandParameter;

       var mm= cvvEntry;
        

        if (cvvValidator.IsNotValid)
        {

            formValidation = true;
            CounterBtn.IsEnabled = true;
            activityIndicator.IsVisible = false;
            activityIndicator.IsRunning = false;
            foreach (var error in cvvValidator.Errors)
            {
                if (error.ToString() == "Cvv field is mandatory")
                {
                    await DisplayAlert("Cvv Error", "" + error.ToString(), "OK");
                    break;
                }
               if(cvvEntry.Text != "" && cvvEntry.Text != null)
                {
                    await DisplayAlert("Cvv Error", "" + error.ToString(), "OK");
                    break;
                }


            }

        }

        if (amountValidator.IsNotValid)
        {
            formValidation = true;
            CounterBtn.IsEnabled = true;
            activityIndicator.IsVisible = false;
            activityIndicator.IsRunning = false;
            foreach (var error in amountValidator.Errors)
            {
                if (error.ToString() == "Ammount field is mandatory")
                {
                    await DisplayAlert("Amount Error", "" + error.ToString(), "OK");
                    break;
                }

                if(amountEntry.Text!="" && amountEntry.Text != null)
                {
                    await DisplayAlert("Amount Error", "" + error.ToString(), "OK");
                    break;
                }

            }
        }

        if (cardExpiryValidator.IsNotValid)
        {
            formValidation = true;
            CounterBtn.IsEnabled = true;
            activityIndicator.IsVisible = false;
            activityIndicator.IsRunning = false;
            foreach (var error in cardExpiryValidator.Errors)
            {
                if (error.ToString() == "Card expiry field is mandatory")
                {
                    await DisplayAlert("card Expiry Error", "" + error.ToString(), "OK");
                    break;

                }
                if (cardExpiryEntry.Text != "" && cardExpiryEntry.Text != null)
                {
                    await DisplayAlert("card Expiry Error", "" + error.ToString(), "OK");
                    break;
                }
            }
            
        }

        if (cardNumberValidator.IsNotValid)
        {
            formValidation = true;
            CounterBtn.IsEnabled = true;
            activityIndicator.IsVisible = false;
            activityIndicator.IsRunning = false;
            foreach (var error in cardNumberValidator.Errors)
            {
                if (error.ToString() == "Card number field is mandatory")
                {
                    await DisplayAlert("card Number Error", "" + error.ToString(), "OK");
                    break;

                }
                if (cardNumberEntry.Text != "" && cardNumberEntry.Text != null)
                {
                    await DisplayAlert("card Number Error", "" + error.ToString(), "OK");
                    break;
                }
            }

        }

        if (lastNameValidator.IsNotValid)
        {
            formValidation = true;
            CounterBtn.IsEnabled = true;
            activityIndicator.IsVisible = false;
            activityIndicator.IsRunning = false;
            foreach (var error in lastNameValidator.Errors)
            {
                if (error.ToString() == "Last name field is mandatory")
                {
                    await DisplayAlert("Last name Error", "" + error.ToString(), "OK");
                    break;

                }
                
            }

        }
        if (firstNameValidator.IsNotValid)
        {
            formValidation = true;
            CounterBtn.IsEnabled = true;
            activityIndicator.IsVisible = false;
            activityIndicator.IsRunning = false;
            foreach (var error in firstNameValidator.Errors)
            {
                if (error.ToString() == "First name field is mandatory")
                {
                    await DisplayAlert("First name Error", "" + error.ToString(), "OK");
                    break;

                }

            }

        }

        if (emailValidator.IsNotValid)
        {
            formValidation = true;
            CounterBtn.IsEnabled = true;
            activityIndicator.IsVisible = false;
            activityIndicator.IsRunning = false;
            foreach (var error in emailValidator.Errors)
            {
                if (error.ToString() == "Email field is mandatory")
                {
                    await DisplayAlert("Email Error", "" + error.ToString(), "OK");
                    break;

                }
                if (emailEntry.Text != "" && emailEntry.Text != null)
                {
                    await DisplayAlert("Email Error", "" + error.ToString(), "OK");
                    break;
                }
            }

        }

        if (!formValidation)
        {
            //await Shell.Current.GoToAsync(nameof(Secured3Dpage));
            await service.PostNewCart(item);

            lastNameEntry.Text= string.Empty;
            firstNameEntry.Text= string.Empty;
            emailEntry.Text= string.Empty;
            cardNumberEntry.Text= string.Empty;
            cardExpiryEntry.Text= string.Empty;
            cvvEntry.Text= string.Empty;
            amountEntry.Text= string.Empty; 

            activityIndicator.IsVisible = false;
            activityIndicator.IsRunning = false;
            CounterBtn.IsEnabled = true;

        }
       
        
        
        

    }

    private void amountEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (amountValidator.IsNotValid)
        {
            foreach (var error in amountValidator.Errors)
            {
                if (error.ToString() == "Only numbers allowed" && cvvEntry.Text != "")

                    DisplayAlert("Error", "" + error.ToString(), "OK");

            }

        }


    }

    private void cardExpiryEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (cardExpiryValidator.IsNotValid)
        {
            foreach (var error in cardExpiryValidator.Errors)
            {
                if (error.ToString() == "Only numbers allowed" && cvvEntry.Text != "")

                    DisplayAlert("Error", "" + error.ToString(), "OK");

            }

        }

    }

    private void cardNumberEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (cardNumberValidator.IsNotValid)
        {
            foreach (var error in cardNumberValidator.Errors)
            {
                if (error.ToString() == "Only numbers allowed" && cvvEntry.Text != "")

                    DisplayAlert("Error", "" + error.ToString(), "OK");

            }

        }

    }
}

