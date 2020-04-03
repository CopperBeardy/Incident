using System.Collections.Generic;
using System.Threading.Tasks;
using IncidentReporter.Models;

namespace IncidentReporter.DataAccess
{
    public interface IIncidentRepository
    {
        Task AddNewIncident(Incident incident);
        Task<List<Incident>> GetAllIncidents();

     
    }
}