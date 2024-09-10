using AppFakeStore.Models;
using AppFakeStore.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFakeStore.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string username;

        [ObservableProperty]
        private string password;

        private readonly ILoginService loginService;
        public LoginViewModel()
        {
            Title = "Login";
            loginService = new LoginService();
        }

        [RelayCommand]
        private async Task Login()
        {
            // comprueba que los campos no esten vacios
            if (string.IsNullOrWhiteSpace(Username))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "El campo usuario esta vacio.", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "El campo contraseña esta vacio.", "OK");
                return;
            }

            // Login
            var loginModel = new Login
            {
                Username = Username,
                Password = Password
            };

            // autenticar
            var token = await loginService.AuthenticateAsync(loginModel);

            if (!string.IsNullOrEmpty(token))
            {

                ResetFields();
                await Application.Current.MainPage.Navigation.PopModalAsync();

            }
            else
            {
                // en caso de error mostrar
                await Application.Current.MainPage.DisplayAlert("Error", "Usuario y/o contraseña incorrectas", "OK");
            }
        }
        //funcion para vaciar los campos al volver al login
        private void ResetFields()
        {
            Username = string.Empty;
            Password = string.Empty;
        }

    }
}
