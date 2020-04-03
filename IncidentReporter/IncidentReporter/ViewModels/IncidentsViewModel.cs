using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using IncidentReporter.Models;
using IncidentReporter.Views;
using Xamarin.Forms;

namespace IncidentReporter.ViewModels
{
    public class IncidentsViewModel : BaseViewModel
    {
        public ObservableCollection<Incident> Incidents { get; set; }
        public Command LoadIncidentsCommand { get; set; }
        public IncidentsViewModel()
        {
            Title = "Incidents Reporter";

            Incidents = new ObservableCollection<Incident>();
            LoadIncidentsCommand = new Command(async () => await ExecutedLoadIncidentsCommand());

           
        }

        async Task ExecutedLoadIncidentsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Incidents.Clear();


                var incidents = await App.IncidentRepo.GetAllIncidents();
                foreach (var incident in incidents)
                {
                    Incidents.Add(incident);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
