using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IncidentReporter.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();
		 
		}

	    protected override async void OnAppearing()
	    {
	        base.OnAppearing();
	        if (App.NotificationMessage != null)
	        {
	            
	            NotificationLabel.IsVisible = true;
	            NotificationLabel.Text = App.NotificationMessage;
	            await Task.Delay(2000);
	            NotificationLabel.IsVisible = false;
	            NotificationLabel.Text = "";
	            App.NotificationMessage = null;
	        }
        }

        

	    private async Task CreateNewIncidentReportBtn_OnClicked(object sender, EventArgs e)
	    {
	        await Navigation.PushAsync(new NewIncidentPage());
	    }

	    private async Task ListOfIncidentsBtn_OnClicked(object sender, EventArgs e)
	    {
	        await Navigation.PushAsync(new IncidentsPage());
        }

	    private async Task MapOfIncidentsBtn_OnClicked(object sender, EventArgs e)
	    {
	        await Navigation.PushAsync(new IncidentsMapPage());
        }
	}
}