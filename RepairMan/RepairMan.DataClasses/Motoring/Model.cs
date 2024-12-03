using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepairMan.DataClasses.Motoring
{
    public class Model
    {
        public Guid ModelId { get; set; }
        public string Name { get; set; }
        
        public Guid BrandId { get; set; }

        [ForeignKey(nameof(BrandId))]
        public Brand Brand { get; set; }
    }
}