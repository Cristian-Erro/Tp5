namespace AppFakeStore.Views;
using AppFakeStore.ViewModels;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
        InitializeComponent();
        BindingContext = new LoginViewModel();
    }
}