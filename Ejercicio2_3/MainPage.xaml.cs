using Plugin.Media;
using System;
using System.IO;
using Xamarin.Forms;

namespace Ejercicio2_3
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        Plugin.Media.Abstractions.MediaFile Filefoto = null;

        private Byte[] ConvertImageToByteArray()
        {
            if (Filefoto != null)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    Stream stream = Filefoto.GetStream();
                    stream.CopyTo(memory);
                    return memory.ToArray();
                }
            }
            return null;

        }

        private async void btnAdd_Clicked(object sender, EventArgs e)
        {
            if (Filefoto == null)
            {
                await this.DisplayAlert("Advertencia", "Debe tomar una foto", "OK");
            }
            else if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                await this.DisplayAlert("Advertencia", "Campo descripcion vacio, Ingrese datos.", "OK");
            }
            else
            {
                var sitio = new Models.Fotos
                {
                    id = 0,
                    descripcion = txtDescripcion.Text,
                    foto = ConvertImageToByteArray(),
                };

                var result = await App.DBase.SitioSave(sitio);

                if (result > 0)
                {
                    await DisplayAlert("Aviso", "Sitio Registrado", "OK");
                    Clear();
                }
                else
                {
                    await DisplayAlert("Aviso", "Error al Registrar", "OK");
                }
            }
        }

        private async void btnList_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.Lista());
        }

        private async void btnFoto_Clicked(object sender, EventArgs e)
        {
            Filefoto = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "MisFotos",
                Name = "test.jpg",
                SaveToAlbum = true,
            });

            if (Filefoto != null)
            {
                fotoSitio.Source = ImageSource.FromStream(() =>
                {
                    return Filefoto.GetStream();
                });

                imagenPlaceholder.IsVisible = false; // Oculta el icono de imagen predeterminado
            }
        }

        private void Clear()
        {
            txtDescripcion.Text = "";
            imagenPlaceholder.IsVisible = true;
            fotoSitio.Source = null;
            Filefoto = null;
        }
    }
}
