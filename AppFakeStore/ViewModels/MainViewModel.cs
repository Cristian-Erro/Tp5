using AppFakeStore.Views;
using CommunityToolkit.Mvvm.Input;

namespace AppFakeStore.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    public MainViewModel()
    {
        Title = "ITES - Demo MVVM";
    }

    [RelayCommand]
    public async Task GoToProductoLista()
    {
        await Application.Current.MainPage.Navigation.PushAsync(new ProductoListaPage());
    }

    [RelayCommand]
    public async Task GoToAcerca()
    {
        await Application.Current.MainPage.Navigation.PushAsync(new AcercaPage());
    }

    [RelayCommand]
    public async Task Exit()
    {
        bool answer = await Application.Current.MainPage.DisplayAlert("Salir", "¿Desea cerrar sesion?", "Aceptar", "Cancelar");

        if (answer)
        {

            // Volver a  inicio de sesión
            await Application.Current.MainPage.Navigation.PopToRootAsync(); // vuelve una pagina atras
            await Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new LoginPage())); // va a la pagina de login
        }
    }

    //comando nuevo para acceder a la lista de usuarios
    [RelayCommand]
    public async Task GoToUsuarioLista()
    {
        await Application.Current.MainPage.Navigation.PushAsync(new UsuarioListaPage());
    }
}
