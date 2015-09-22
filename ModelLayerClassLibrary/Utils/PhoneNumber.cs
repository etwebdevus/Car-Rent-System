using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayerClassLibrary.Utils
{
    public class PhoneNumber
    {
        public string Phone { get; set; }

        public string DDD { get; set; }

        public PhoneNumber() { }

        public override string ToString()
        {
            return string.Format("({0}) {1}", DDD, Phone);
        }
    }
}
