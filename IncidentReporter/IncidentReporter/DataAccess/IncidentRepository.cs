using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncidentReporter.Helpers;
using IncidentReporter.Models;
using SQLite;

namespace IncidentReporter.DataAccess
{
    
    public class IncidentRepository : IIncidentRepository
    {
        private readonly SQLiteAsyncConnection _conn;

        public IncidentRepository(string dbPath)
        {
            _conn = new SQLiteAsyncConnection(dbPath);
            _conn.CreateTableAsync<Incident>();
        }

        public async Task AddNewIncident(Incident incident)
        {
            var result = 0;
            try
            {
                if (string.IsNullOrEmpty(incident.Heading))
                    throw new Exception("Heading is required");
                if (string.IsNullOrEmpty(incident.Type))
                    throw new Exception("Type of incident is required");
                if (string.IsNullOrEmpty(incident.IncidentDescription))
                    throw new Exception("Description of incident is required");

                var locator = new GpsHelper();
                var position = await locator.GetLocation();

                result = await _conn.InsertAsync(new Incident
                {
                    Heading = incident.Heading,
                    Type =   incident.Type,
                    Location = incident.Location,
                    GPSLongitude = position.Longitude,
                    GPSLatitude =  position.Latitude,
                    DateReported = DateTime.Now,
					ImageUrl = incident.ImageUrl,
                    IncidentDescription = incident.IncidentDescription,

                });
              
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<Incident>> GetAllIncidents()
        {
            try
            {
                return await _conn.Table<Incident>().ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
               // StatusMessage = string.Format($"Unable to get Incidents.  {e.Message}");
            }
            return  new List<Incident>();
        }

       
    }
}
