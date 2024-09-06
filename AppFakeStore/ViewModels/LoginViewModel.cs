using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFakeStore.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {

        public LoginViewModel()
        {
           
        }

        [RelayCommand]
        private async Task Logeo()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new MainPage());
        }

    }
}
