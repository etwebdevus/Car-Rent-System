using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayerClassLibrary.Abstract;

namespace ModelLayerClassLibrary.Interfaces
{
    public interface IRent
    {
        int RentID { get; set; }

        int CarID { get; set; }
        ICar Car { get; set; }

        int UserID { get; set; }
        User User { get; set; }
    }
}
