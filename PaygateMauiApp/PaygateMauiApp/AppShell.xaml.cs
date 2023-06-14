namespace PaygateMauiApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(Secured3Dpage), typeof(Secured3Dpage));
        Routing.RegisterRoute(nameof(ResultPage), typeof(ResultPage));
    }
}

