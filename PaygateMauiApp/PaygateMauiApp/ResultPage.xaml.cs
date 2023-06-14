using PaygateMauiApp.ViewModels;

namespace PaygateMauiApp;

public partial class ResultPage : ContentPage
{
	public ResultPage(ResultPageModel rpm)
	{
		InitializeComponent();
		BindingContext= rpm;
	}
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}