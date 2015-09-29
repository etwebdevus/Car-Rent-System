using ModelLayerClassLibrary.Entities;
using ModelLayerClassLibrary.Repositories;
using ServiceClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClassLibrary.ModelServiceLayer
{
    public class ModelServices : IService<Model>
    {
        IRepository<Model> modelRepo = new ModelRepository(new WebAppRentSysDbContext());

        public List<Model> GetAll()
        {
            return modelRepo.GetAll();
        }

        public Model GetByID(int id)
        {
            return modelRepo.GetByID(id);
        }

        public void Add(Model item)
        {
            modelRepo.Add(item);
        }

        public void Delete(int id)
        {
            modelRepo.Delete(id);
        }

        public void Update(Model item)
        {
            modelRepo.Update(item);
        }

        public void Save()
        {
            modelRepo.Save();
        }

        public void Dispose()
        {
            modelRepo.Dispose();
        }
    }
}
