using AQCSApp.UIForms.ViewModels;
using AQCSApp.UIForms.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AQCSApp.UIForms
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainViewModel.GetInstance().Login = new LoginViewModel();
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
