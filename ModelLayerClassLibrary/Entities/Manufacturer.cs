using ModelLayerClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayerClassLibrary.Entities
{
    public class Manufacturer : IManufacturer
    {
        public int ManufacturerID { get; set; }
        public string Name { get; set; }
        public virtual List<IModel> Models { get; set; }

        public Manufacturer() { }
    }
}
