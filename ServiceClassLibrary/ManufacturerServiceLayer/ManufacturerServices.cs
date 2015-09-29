using ModelLayerClassLibrary.Entities;
using ModelLayerClassLibrary.Repositories;
using ServiceClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClassLibrary.ManufacturerServiceLayer
{
    public class ManufacturerServices : IService<Manufacturer>
    {
        private IRepository<Manufacturer> manuRepo = new ManufacturerRepository(new WebAppRentSysDbContext());

        public List<Manufacturer> GetAll()
        {
            return manuRepo.GetAll();
        }

        public Manufacturer GetByID(int id)
        {
            return manuRepo.GetByID(id);
        }

        public void Add(Manufacturer item)
        {
            manuRepo.Add(item);
        }

        public void Delete(int id)
        {
            manuRepo.Delete(id);
        }

        public void Update(Manufacturer item)
        {
            manuRepo.Update(item);
        }

        public void Save()
        {
            manuRepo.Save();
        }

        public void Dispose()
        {
            manuRepo.Dispose();
        }
    }
}
