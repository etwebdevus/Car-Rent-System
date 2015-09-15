using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayerClassLibrary.Interfaces
{
    public interface IModel
    {
        int ModelID { get; set; }
        string Name { get; set; }
        decimal Engine { get; set; }

        int ManufacturerID { get; set; }
        IManufacturer Manufacturer { get; set; }
    }
}
