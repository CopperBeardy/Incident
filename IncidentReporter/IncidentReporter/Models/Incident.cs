using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace IncidentReporter.Models
{
    [Table("incident")]
    public class Incident
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Heading { get; set; }

        public DateTime DateReported { get; set; }

        [MaxLength(200)]
        public string Type { get; set; }
        public string Location { get; set; }

        public double GPSLongitude { get; set; }
        public double GPSLatitude { get; set; }
      
        [MaxLength(500)]
        public string IncidentDescription { get; set; }
        public string ImageUrl { get; set; }
    }
}
