using ModelLayerClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClassLibrary.Interfaces
{
    interface IServiceCar : IService<Car>
    {
        List<Model> GetModels(int manuId);
    }
}
