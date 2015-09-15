using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayerClassLibrary.Enum;

namespace ModelLayerClassLibrary.Interfaces
{
    public interface ICar
    {
        int CarID { get; set; }
        string LicensePlate { get; set; }
        EnumColor CarColor { get; set; }
        int Category { get; set; }
        
        int ModelID { get; set; }
        IModel Model { get; set; }
    }
}
