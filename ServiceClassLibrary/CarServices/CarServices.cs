using ModelLayerClassLibrary.Entities;
using ModelLayerClassLibrary.Repositories;
using ServiceClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClassLibrary.CarServices
{
    public class CarServices : IService<Car>
    {
        private IRepository<Car> carRepo = new CarRepository(new WebAppRentSysDbContext());

        public List<Car> GetAll()
        {
            return carRepo.GetAll();
        }

        public Car GetByID(int id)
        {
            return carRepo.GetByID(id);
        }

        public void Add(Car item)
        {
            carRepo.Add(item);
        }

        public void Delete(int id)
        {
            carRepo.Delete(id);
        }

        public void Update(Car item)
        {
            carRepo.Update(item);
        }

        public void Save()
        {
            carRepo.Save();
        }

        public void Dispose()
        {
            carRepo.Dispose();
        }
    }
}
