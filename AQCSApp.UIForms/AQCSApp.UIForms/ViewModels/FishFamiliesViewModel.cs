
using AQCSApp.Common.Models;
using AQCSApp.Common.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace AQCSApp.UIForms.ViewModels
{
    public class FishFamiliesViewModel : BaseViewModel
    {
        private readonly ApiService apiService;
        private ObservableCollection<FishFamily> fishfamilies;
        private bool iSRefreshing;

        public ObservableCollection<FishFamily> FishFamilies
        {
            get => this.fishfamilies;
            set => this.SetValue(ref this.fishfamilies, value);
        }
        public bool IsRefreshing
        {
            get => this.iSRefreshing;
            set => this.SetValue(ref this.iSRefreshing, value);
        }

        public FishFamiliesViewModel()
        {
            this.apiService = new ApiService();
            this.LoadFishFamilies();
        }
        private async void LoadFishFamilies()
        {
            this.iSRefreshing = true;

            var response = await this.apiService.GetListAsync<FishFamily>(
                "https://aqcsapp.azurewebsites.net",
                "/api",
                "/FishFamilies");

            this.iSRefreshing = false;

            if (response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                return;
            }
            var Families = (List<FishFamily>)response.Result;
            this.FishFamilies = new ObservableCollection<FishFamily>(Families);
        }

    }
}
