using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncidentReporter.Helpers;
using IncidentReporter.Models;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IncidentReporter.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewIncidentPage : ContentPage
    {
        public Incident Incident { get; set; }

        public NewIncidentPage()
        {
            InitializeComponent();

            TypePicker.ItemsSource = GetIncidentTypes();

            Incident = new Incident
            {
                Heading = "",
                IncidentDescription = "",
                Location = "",
            };

            BindingContext = this;
        }

        private List<string> GetIncidentTypes()
        {
            var typelist = new List<string>();
            typelist.Add("Vandalism");
            typelist.Add("Theft");
            typelist.Add("Littering");
            typelist.Add("Animal Fouling");
            typelist.Add("Suspicious Behavior");
            typelist.Add("Disturbance");
            typelist.Add("Abusive Actions");
            typelist.Add("Loud Noise");

            return typelist;
        }

        async void ReportIncident_OnClicked(object sender, EventArgs e)
        {
            if (TitleEntry.Text.Length > 0 &&
             
                IncidentDescriptionEditor.Text.Length > 0)
            {
                

                await App.IncidentRepo.AddNewIncident(Incident);
                App.NotificationMessage = $"{Incident.Heading} incident  has be successfully reported";
                await Navigation.PopAsync();
            }




        }

        public async void TakePhoto_OnClicked(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Test",
                SaveToAlbum = true,
                CompressionQuality = 75,
                CustomPhotoSize = 50,
                PhotoSize = PhotoSize.Small,
                DefaultCamera = CameraDevice.Front
            });

            if (file == null)
                return;

            TakePhoto.Text = "Retake";
            Incident.ImageUrl = file.Path;
            image.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });
        }

        private void TitleEntry_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            CanSend();
        }

       

        private void IncidentDescriptionEditor_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            CanSend();
        }

        private void CanSend()
        {
            if (TitleEntry.Text != "" &&  IncidentDescriptionEditor.Text != "")
            {
                ReportIncident.IsVisible = true;
            }
            else
            {
                ReportIncident.IsVisible= false;
            }
        }

        async void Cancel_OnClicked(object sender, EventArgs e)
        {

            await Navigation.PopAsync();

        }
    }
}