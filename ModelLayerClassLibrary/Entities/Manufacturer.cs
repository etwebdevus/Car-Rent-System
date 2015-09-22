using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayerClassLibrary.Entities
{
    public class Manufacturer
    {
        public int ManufacturerID { get; set; }
        
        public string Name { get; set; }
        public virtual List<Model> Models { get; set; }

        public Manufacturer() { }
    }
}
