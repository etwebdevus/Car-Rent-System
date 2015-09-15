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
        private const int MaxPhoneLength = 8;

        public string DDD { get; set; }
        private const int MaxDDDLength = 3;

        public bool IsValid()
        {
            return true;
        }
    }
}
