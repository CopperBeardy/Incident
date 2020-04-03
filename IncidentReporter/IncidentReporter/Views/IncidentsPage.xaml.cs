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
using Xamarin.Forms.Xaml;

namespace IncidentReporter.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IncidentsPage : ContentPage
    {
        IncidentsViewModel _viewModel;
        public IncidentsPage()
        {
            InitializeComponent();
            Title = "Reported Incidents";
            BindingContext = _viewModel = new IncidentsViewModel();
        }

        async void OnIncidentSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var incident = args.SelectedItem as Incident;
           
            if (incident == null)
                return;
     
            await Navigation.PushAsync(new IncidentDetailPage(new IncidentViewModel(incident)));

            // Manually deselect item.
            IncidentsListView.SelectedItem = null;

        }


        protected override void OnAppearing()
        {


            if (_viewModel.Incidents.Count == 0)
                _viewModel.LoadIncidentsCommand.Execute(null);
            base.OnAppearing();
        }


    }
}