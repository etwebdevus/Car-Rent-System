using ModelLayerClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayerClassLibrary.Entities
{
    public class Model : IModel
    {
        public int ModelID { get; set; }
        public string Name { get; set; }
        public decimal Engine { get; set; }

        public int ManufacturerID { get; set; }
        public virtual IManufacturer Manufacturer { get; set; }

        public Model() { }
    }
}
