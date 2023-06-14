using Android.Graphics;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Graphics;
using PaygateMauiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Color = Microsoft.Maui.Graphics.Color;

namespace PaygateMauiApp.ViewModels
{
    [QueryProperty("CardResponseModel", "CardResponseModel")]
    public partial class ResultPageModel:ObservableObject
    {
        public ResultPageModel()
        {
            //CardResponseModel = new CardPaymentResponse();
        }


       
    


        //public string StatusName => CardResponseModel?.Response?.Split("StatusName")[1].Split(",")[0].Split(": ")[1].ToString().Replace("\"", String.Empty);

        //public string TransactionStatusDescription => CardResponseModel?.Response?.Split("TransactionStatusDescription")[1].Split(",")[0].Split(": ")[1].ToString().Replace("\"", String.Empty);



        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(RequestId), nameof(StatusName), nameof(TransactionStatusDescription), nameof(Color))]
        CardPaymentResponse cardResponseModel;

        public string RequestId
        {
            get
            {
                if(CardResponseModel != null)
                {
                    if (CardResponseModel.Response != null)
                    {
                        return CardResponseModel.Response.Split("PayRequestId")[1].Split(",")[0].Split(":")[1].Replace("\"", String.Empty);
                    }
                    

                }
                return "No Result";
               
            }
        }

        public string StatusName
        {
            get
            {
                if (CardResponseModel != null)
                {
                    if (CardResponseModel.Response != null)
                    {
                        return CardResponseModel.Response.Split("StatusName")[1].Split(",")[0].Split(":")[1].Replace("\"", String.Empty);
                    }


                }
                return "No Result";

            }
        }

        public string TransactionStatusDescription
        {
            get
            {
                if (CardResponseModel != null)
                {
                    if (CardResponseModel.Response != null)
                    {
                        return CardResponseModel.Response.Split("TransactionStatusDescription")[1].Split(",")[0].Split(":")[1].Replace("\"", String.Empty);
                    }


                }
                return "No Result";

            }
        }

        public Color Color
        {
            get
            {
                if (CardResponseModel != null)
                {
                    if (CardResponseModel.Response != null)
                    {
                        var stringResult= CardResponseModel.Response.Split("TransactionStatusDescription")[1].Split(",")[0].Split(":")[1].Replace("\"", String.Empty);
                        if(stringResult != "Approved")
                        {
                            return Colors.Red;
                        }
                        else
                        {
                            return Colors.Green;
                        }
                    }


                }
                return Colors.Green;

            }
        }

    }
}
