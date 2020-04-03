using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncidentReporter.Models;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace IncidentReporter.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class IncidentLocationPage : ContentPage
	{
	    private Incident _incident;
		public IncidentLocationPage (Incident incident)
		{
		    
			InitializeComponent ();
		    Title = $"{incident.Heading} Incident Location";
		    _incident = incident;

		}

	    protected override void OnAppearing()
	    {
	        base.OnAppearing();


	        LocationMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(_incident.GPSLatitude,_incident.GPSLongitude),
	            Distance.FromKilometers(5)));

	        var pin = new Pin
	        {
                Position = new Position(_incident.GPSLatitude,_incident.GPSLongitude),
                    Label = _incident.Heading
	        };
            LocationMap.Pins.Add(pin);
	    }

	    protected override  void OnDisappearing()
	    {
	        _incident = null;
	      
            base.OnDisappearing();
	    }

	  
    }
}