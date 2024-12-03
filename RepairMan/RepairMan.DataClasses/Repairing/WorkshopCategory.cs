using System;
using System.Collections.Generic;

namespace RepairMan.DataClasses.Repairing
{
    public class WorkshopCategory
    {
        public Guid WorkshopCategoryId { get; set; }

        public string Name { get; set; }

        public string Icon { get; set; }

        public string Color { get; set; }

        public List<string> Keywords { get; set; } 
    }
}
