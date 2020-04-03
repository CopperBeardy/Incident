using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncidentReporter.Models;
using IncidentReporter.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IncidentReporter.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IncidentDetailPage : ContentPage
    {
         IncidentViewModel _incidentViewModel;
        private string imageUrl;

        public IncidentDetailPage(IncidentViewModel incidentViewModel)
        {
            InitializeComponent();
            
            _incidentViewModel = incidentViewModel;
          
            imageUrl = incidentViewModel.Incident.ImageUrl;
            if (string.IsNullOrEmpty(imageUrl))
            {
                imageLabel.IsVisible = false;
                image.IsVisible = false;
                
            }
         

            BindingContext = this._incidentViewModel = incidentViewModel;
        }

       

      

        private async Task OnTapCommand(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new ImagePage(_incidentViewModel.Incident));
        }

        private async Task ViewLocationButton_OnClicked(object sender, EventArgs e)
        {
            
          await  Navigation.PushAsync(new IncidentLocationPage(_incidentViewModel.Incident));
        }


        
    }
}