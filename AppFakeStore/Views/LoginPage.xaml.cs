namespace AppFakeStore.Views;
using AppFakeStore.ViewModels;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();

        LoginViewModel viewModel = new LoginViewModel();
        this.BindingContext = viewModel;
    }
}