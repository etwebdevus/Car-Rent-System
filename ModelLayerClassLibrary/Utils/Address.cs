using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayerClassLibrary.Enum;

namespace ModelLayerClassLibrary.Utils
{
    public class Address
    {
        public EnumState State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public int Number { get; set; }

        public Address() { }

        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3} - {4}", Street, Number, District, City, State);
        }
    }
}
