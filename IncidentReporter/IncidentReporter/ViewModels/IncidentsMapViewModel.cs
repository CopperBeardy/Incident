using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using IncidentReporter.Models;

namespace IncidentReporter.ViewModels
{
   public class IncidentsMapViewModel : BaseViewModel
    {

        public ObservableCollection<Incident> Incidents { get; set; }

        public async Task<List<Incident>> GetIncidents()
        {
            if (IsBusy)
                return null;

            IsBusy = true;
            try
            {
                return  await App.IncidentRepo.GetAllIncidents();;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
