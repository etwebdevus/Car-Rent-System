using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayerClassLibrary.Entities
{
    public class Model
    {
        public int ModelID { get; set; }
        public string Name { get; set; }
        public double Engine { get; set; }
        public int Category { get; set; }

        public int ManufacturerID { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }

        public Model() { }
    }
}
