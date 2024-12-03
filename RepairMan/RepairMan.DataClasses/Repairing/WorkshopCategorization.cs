using System;
using System.Collections.Generic;
using System.Text;

namespace RepairMan.DataClasses.Repairing
{
    public class WorkshopCategorization
    {
        public Guid WorkshopCategorizationId { get; set; }
        public Guid WorkshopId { get; set; }
        public Workshop Workshop { get; set; }
        public Guid WorkshopCategoryId { get; set; }
        public WorkshopCategory WorkshopCategory { get; set; }
    }
}
