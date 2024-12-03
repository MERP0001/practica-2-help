using System;
namespace RepairMan.DataClasses.Repairing
{
    public class Offer
    {
        public Guid OfferId { get; set; }

        public Guid WorkshopId { get; set; }

        public Workshop Workshop { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Keywords { get; set; }

        public decimal Price { get; set; }

        public Guid CategoryId { get; set; }

        public WorkshopCategory Category { get; set; }

        public DateTime AvailableFrom { get; set; }

        public DateTime AvailableUntil { get; set; }
    }
}
