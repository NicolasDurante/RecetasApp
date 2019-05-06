﻿namespace RecetasApp.UIForms.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using RecetasApp.Common.Models;
    using RecetasApp.Common.Services;
    using Xamarin.Forms;

    public class RecetasViewModel : BaseViewModel
    {
        private readonly ApiService apiSevice;
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
            this.apiSevice = new ApiService();
            this.LoadRecetas();
        }

        private async void LoadRecetas()
        {
            this.IsRefreshing = true;

            var response = await this.apiSevice.GetListAsync<Receta>(
                "http://192.168.0.23/CoreReceta/", 
                "api", 
                "/Recetas");

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