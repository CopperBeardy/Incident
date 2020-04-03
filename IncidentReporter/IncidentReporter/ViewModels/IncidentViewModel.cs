using System;
using System.Collections.Generic;
using System.Text;
using IncidentReporter.Models;

namespace IncidentReporter.ViewModels
{
    public class IncidentViewModel : BaseViewModel
    {
        public Incident Incident { get; set; }
        public IncidentViewModel(Incident incident)
        {
            Title = "Incident Reporter";
            Incident = incident;


        }


    }
}
