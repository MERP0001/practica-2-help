using RepairMan.DataClasses.Common;
using RepairMan.DataClasses.Motoring;
using RepairMan.DataClasses.Scoring;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepairMan.DataClasses.Repairing
{
    public class Workshop
    {
        public Guid WorkshopId { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public IList<WorkshopCategorization> Categorization { get; set; } = new List<WorkshopCategorization>();
        public IList<ModelSpecialization> ModelSpecializations { get; set; } = new List<ModelSpecialization>();
        public IList<BrandSpecialization> BrandSpecializations { get; set; } = new List<BrandSpecialization>();
        public Guid ContactId { get; set; }
        public Contact Contact { get; set; }
        public Guid OwnerId { get; set; }
        [ForeignKey(nameof(OwnerId))]
        public User Owner { get; set; } 
        public string ImageUrl { get; set; }
        public Geoposition Geoposition { get; set; }
        public Guid? GeopositionId { get; set; }
        public Guid? DocumentId { get; set; }
        [ForeignKey(nameof(DocumentId))]
        public IdentityDocument Document { get; set; }
        public IList<Qualification> Qualifications { get; set; } = new List<Qualification>();
        public IList<WorkshopProduct> Products { get; set; } = new List<WorkshopProduct>();
        public bool IsActive { get; set; } = false;
    }
}
