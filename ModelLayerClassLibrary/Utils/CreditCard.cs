using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayerClassLibrary.Utils
{
    public class CreditCard
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public string SecurityNumber { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public CreditCard() { }

        public override string ToString()
        {
            return string.Format("{0} - {1}/{2}", Number, Month, Year);
        }
    }
}
