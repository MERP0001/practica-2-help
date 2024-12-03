using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepairMan.DataClasses.Common
{
    public class Geoposition
    {
        public Guid GeopositionId { get; set; }

        [Column(TypeName = "decimal(10,8)")]
        public double Latitude { get; set; }

        [Column(TypeName = "decimal(10,8)")]
        public double Longitude { get; set; }
        public DateTime Date { get; set; }

        public Geoposition()
        {
            Date = DateTime.UtcNow;
        }
        public Geoposition(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
