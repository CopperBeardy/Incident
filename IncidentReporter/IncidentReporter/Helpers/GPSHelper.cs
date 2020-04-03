using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using IncidentReporter.Models;
using Plugin.Geolocator;

namespace IncidentReporter.Helpers
{
    public  class GpsHelper
    {
        public  async Task<EventPosition> GetLocation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;

            var loc = await locator.GetPositionAsync(TimeSpan.FromMilliseconds(10000));
            var pos = new EventPosition
            {
                Longitude = loc.Longitude,
                Latitude = loc.Latitude

            };

            return pos;

        }
    }
}
