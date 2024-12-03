using RepairMan.DataClasses.Common;
using RepairMan.DataClasses.Repairing;
using System;
using System.Collections.Generic;

namespace RepairMan.DataClasses.Advertising
{
    public class AdvertisementContext
    {
        public Guid Id { get; set; }
        public Guid? GeopositionId { get; set; }
        public Geoposition Geoposition { get; set; }
        public float Range { get; set; }
        public Guid? WorkshopCategoryId { get; set; }
        public WorkshopCategory WorkshopCategory { get; set; }
        public string Url { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public IList<Advertisement> Advertisements { get; set; }
    }
}
