namespace RecetasApp.UIForms.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using RecetasApp.UIForms.Views;
    using System;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public ICommand LoginCommand => new RelayCommand(Login);



        private async void Login()
        {
            if(string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes introducir un email.",
                    "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes introducir una contraseña.",
                    "Aceptar");
                return;
            }

            if(!this.Email.Equals("fer-nicolas-durante@hotmail.com") || !this.Password.Equals("1234"))
            {

                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Usuario o contraseña incorrectos",
                    "Aceptar");
                return;
            }
            /*
            await Application.Current.MainPage.DisplayAlert(
                    "Ok",
                    "Abarajame la bañera",
                    "Aceptar");
            */

            MainViewModel.GetInstance().Recetas = new RecetasViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new RecetasPage());
        }
    }
}
