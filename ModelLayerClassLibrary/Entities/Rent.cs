using ModelLayerClassLibrary.Abstract;
using ModelLayerClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayerClassLibrary.Entities
{
    public class Rent : IRent
    {
        public int RentID { get; set; }

        public int CarID { get; set; }
        public virtual ICar Car { get; set; }

        public int UserID { get; set; }
        public virtual User User { get; set; }

        public Rent() { }
    }
}
