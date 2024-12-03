using System;

namespace RepairMan.DataClasses.Repairing
{
    public enum WorkshopProductType
    {
        Service,
        Product
    }

    public class WorkshopProduct
    {
        public Guid WorkshopProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public Guid WorkshopId { get; set; }
        public Workshop Workshop { get; set; }
        public decimal Price { get; set; }
        public WorkshopProductType ProductType { get; set; }
    }
}
