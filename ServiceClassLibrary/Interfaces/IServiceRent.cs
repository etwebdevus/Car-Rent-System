using ModelLayerClassLibrary.Abstract;
using ModelLayerClassLibrary.Entities;
using ModelLayerClassLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClassLibrary.Interfaces
{
    public interface IServiceRent : IService<Rent>
    {
        List<Client> GetClients(string p);

        List<Car> GetCars(string p);
    }
}
