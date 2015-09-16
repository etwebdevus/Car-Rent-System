using ModelLayerClassLibrary.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayerClassLibrary.Entities
{
    public class Car
    {
        public int CarID { get; set; }
        public string LicensePlate { get; set; }
        public EnumColor CarColor { get; set; }
        public int Category { get; set; }

        public int ModelID { get; set; }
        public virtual Model Model { get; set; }

        public Car() { }
    }
}
