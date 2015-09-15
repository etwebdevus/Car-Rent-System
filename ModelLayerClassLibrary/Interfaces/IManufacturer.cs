using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayerClassLibrary.Interfaces
{
    public interface IManufacturer
    {
        int ManufacturerID { get; set; }
        string Name { get; set; }
        List<IModel> Models { get; set; }
    }
}
