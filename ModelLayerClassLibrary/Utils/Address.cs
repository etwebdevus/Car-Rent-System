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
        public int Number { get; set; }

        public bool IsValid()
        {
            return true;
        }
    }
}
