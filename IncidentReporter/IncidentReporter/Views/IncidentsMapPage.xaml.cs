using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncidentReporter.Helpers;
using IncidentReporter.Models;
using IncidentReporter.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace IncidentReporter.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IncidentsMapPage : ContentPage
    {
        private List<Incident> incidents;
        private IncidentsMapViewModel viewModel = new IncidentsMapViewModel();
        public IncidentsMapPage ()
        {
            
            InitializeComponent ();
            Title = "Incidents Reporter";
        }

    


        protected override async void OnAppearing()
        {
            base.OnAppearing();

            GpsHelper gpsHelper = new GpsHelper();
            var currentPostion = await gpsHelper.GetLocation();

            MainMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(currentPostion.Latitude,currentPostion.Longitude),
                Distance.FromKilometers(5)));

            List<Pin> pins = await GetPins();

            foreach (var pin in pins)
            {
                pin.Clicked += Pin_Clicked;
                  MainMap.Pins.Add(pin);
            }

        
          
        }

        public async Task<List<Pin>> GetPins()
        {
            var pins = new List<Pin>();
           incidents= await GetIncidents();
            foreach (var incident in incidents)
            {
                var pin = new Pin
                {
                    Position = new Position(incident.GPSLatitude,incident.GPSLongitude),
                    Label = incident.Heading
                };
                pins.Add(pin);
            }

            return pins;
        }

        public async void Pin_Clicked(object sender, EventArgs eventArgs)
        {
            var pinSelected = sender as Pin;
            var pinLabelText = pinSelected?.Label;
            Incident incident = null;
            if (pinLabelText != null)
            {
                incident = incidents.FirstOrDefault(i => i.Heading == pinLabelText);
            }

            await Navigation.PushAsync(new IncidentDetailPage(new IncidentViewModel(incident)));

        }

        public async Task<List<Incident>> GetIncidents()
        {
            return await viewModel.GetIncidents();
        }

      
      

        
      
    }
}