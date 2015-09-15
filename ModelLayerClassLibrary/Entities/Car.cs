using ModelLayerClassLibrary.Enum;
using ModelLayerClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayerClassLibrary.Entities
{
    public class Car : ICar
    {
        public int CarID { get; set; }
        public string LicensePlate { get; set; }
        public EnumColor CarColor { get; set; }
        public int Category { get; set; }

        public int ModelID { get; set; }
        public virtual IModel Model { get; set; }

        public Car() { }
    }
}
