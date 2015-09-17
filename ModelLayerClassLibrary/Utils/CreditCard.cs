using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayerClassLibrary.Utils
{
    public class CreditCard
    {
        public string Name { get; set; }
        //private int nameMaxMaxSize;
        public string Number { get; set; }
        //private int numberSie;
        public string SecurityNumber { get; set; }
        //private int securityNumberMaxSize;
        public int Month { get; set; }
        public int Year { get; set; }

        public CreditCard() { }

        public override string ToString()
        {
            return string.Format("{0} - {1}/{2}", Number, Month, Year);
        }
    }
}
