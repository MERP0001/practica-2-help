using RepairMan.DataClasses.Common;
using RepairMan.DataClasses.Repairing;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepairMan.DataClasses.Scoring
{
    public class Qualification
    {
        public Guid Id { get; set; }
        public decimal Points { get; set; }
        public string Comment { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid WorkshopId { get; set; }
        public Workshop Workshop { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
