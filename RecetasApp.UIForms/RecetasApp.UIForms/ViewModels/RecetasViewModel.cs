namespace RecetasApp.UIForms.ViewModels
{
    using RecetasApp.Common.Models;
    using RecetasApp.Common.Services;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;

    public class RecetasViewModel : BaseViewModel
    {
        private readonly ApiService apiService;
        private ObservableCollection<Receta> recetas;
        private bool isRefreshing;

        public ObservableCollection<Receta> Recetas
        {
            get { return this.recetas; }
            set { this.SetValue(ref this.recetas, value); }
        }
        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { this.SetValue(ref this.isRefreshing, value); }
        }


        public RecetasViewModel()
        {
            this.apiService = new ApiService();
            this.LoadRecetas();
        }

        private async void LoadRecetas()
        {
            this.IsRefreshing = true;

            var url = Application.Current.Resources["UrlAPI"].ToString();
            var response = await this.apiService.GetListAsync<Receta>(
                url,
                "api",
                "/Recetas",
                "bearer",
                MainViewModel.GetInstance().Token.Token);



            this.IsRefreshing = false;


            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                return;
            }

            var myRecetas = (List<Receta>)response.Result;
            this.Recetas = new ObservableCollection<Receta>(myRecetas);
        }
    }
}
