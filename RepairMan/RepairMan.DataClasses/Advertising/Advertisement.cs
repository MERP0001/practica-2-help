using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepairMan.DataClasses.Advertising
{
    public class Advertisement
    {
        public Guid AdvertisementId { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Relevance { get; set; }
        public string ImageUrl { get; set; }

        public Guid ContextId { get; set; }

        [ForeignKey(nameof(ContextId))]
        public AdvertisementContext Context { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
