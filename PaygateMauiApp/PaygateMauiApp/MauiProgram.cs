using CommunityToolkit.Maui;
using PaygateMauiApp.Services;
using PaygateMauiApp.ViewModels;

namespace PaygateMauiApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});


		builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
        builder.Services.AddHttpClient<IMerchantService, MerchantService>();

        builder.Services.AddSingleton<MainPageViewModel>();
        builder.Services.AddSingleton<MainPage>();	
		
		builder.Services.AddTransient<Secured3Dpage>();
        builder.Services.AddTransient<Secured3DViewModel>();

        builder.Services.AddTransient<ResultPage>();
        builder.Services.AddTransient<ResultPageModel>();

        return builder.Build();
	}
}
