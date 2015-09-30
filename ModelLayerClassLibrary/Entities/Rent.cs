using ModelLayerClassLibrary.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayerClassLibrary.Entities
{
    public class Rent
    {
        public int RentID { get; set; }

        public int CarID { get; set; }
        public virtual Car Car { get; set; }

        public int UserID { get; set; }
        public virtual User User { get; set; }

        public DateTime PickupDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public decimal Price { get; set; }

        public Rent() { }
    }
}
