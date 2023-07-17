using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio2_3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Lista : ContentPage
    {
        public Lista()
        {
            InitializeComponent();
        }

        private async void Cargar_Sitios()
        {
            var sitios = await App.DBase.getListSitio();
            ListaFoto.ItemsSource = sitios;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Cargar_Sitios();
        }
    }
}