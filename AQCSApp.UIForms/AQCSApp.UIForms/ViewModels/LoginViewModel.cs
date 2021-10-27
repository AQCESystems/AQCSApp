using AQCSApp.UIForms.Views;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using Xamarin.Forms;

namespace AQCSApp.UIForms.ViewModels
{
    public class LoginViewModel 
    {
        public string Email { get; set; }
        public string Password { get; set; }

        //NOTA 
        /// Este codigo  se puede cambiar por el formato delegado que sería
        //public ICommnadn LoginCommand => new RelayCommand(Login);
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }
        //
        public LoginViewModel()
        {
            this.Email = "a";
            this.Password = "1";
        }

        public async void Login()
        {
            if(string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter an email.",
                    "Accept");
                return;
            }
            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter a Password.",
                    "Accept");
                return;
            }
            if(!this.Email.Equals("hola") || !this.Password.Equals("1"))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "User or Password. Wrong",
                    "Accept");
                return;
            }
            MainViewModel.GetInstance().FishFamilies = new FishFamiliesViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new FishFamiliesPage());
        }
    }
}
