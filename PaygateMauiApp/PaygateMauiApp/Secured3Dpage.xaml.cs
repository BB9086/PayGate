using PaygateMauiApp.ViewModels;

namespace PaygateMauiApp;

public partial class Secured3Dpage : ContentPage
{
	public Secured3Dpage(Secured3DViewModel svm)
	{
		InitializeComponent();
		BindingContext= svm;	
	}
}