using System;
using System.Collections.Generic;

namespace RepairMan.DataClasses.Motoring
{
    public class Brand
    {
        public Guid BrandId { get; set; }
        public string Name { get; set; }
        public IList<Model> Models { get; set; }
    }
}