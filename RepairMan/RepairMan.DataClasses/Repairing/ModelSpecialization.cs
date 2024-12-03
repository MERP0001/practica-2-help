using RepairMan.DataClasses.Motoring;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepairMan.DataClasses.Repairing
{
    public class ModelSpecialization
    {
        public Guid ModelSpecializationId { get; set; }
        public Guid WorkshopId { get; set; }
        public Workshop Workshop { get; set; }
        public Guid ModelId { get; set; }
        public Model Model { get; set; }
    }
}
