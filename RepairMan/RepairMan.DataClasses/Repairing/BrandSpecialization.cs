using RepairMan.DataClasses.Motoring;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepairMan.DataClasses.Repairing
{
    public class BrandSpecialization
    {
        public Guid BrandSpecializationId { get; set; }
        public Guid WorkshopId { get; set; }
        public Workshop Workshop { get; set; }
        public Guid BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}
