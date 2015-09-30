using ModelLayerClassLibrary.Entities;
using ModelLayerClassLibrary.Repositories;
using ServiceClassLibrary.Interfaces;
using ServiceClassLibrary.ModelServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClassLibrary.CarServiceLayer
{
    public class CarServices : IServiceCar
    {
        private IRepository<Car> carRepo = new CarRepository(new WebAppRentSysDbContext());
        private IService<Model> modelService = new ModelServices();

        public List<Model> GetModels(int manuId)
        {
            return modelService.GetAll().Where(x => x.ManufacturerID == manuId).ToList();
        }

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
