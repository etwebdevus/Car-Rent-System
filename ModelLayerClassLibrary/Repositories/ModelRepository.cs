using ModelLayerClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayerClassLibrary.Repositories
{
    public class ModelRepository : IRepository<Model>
    {
        private WebAppRentSysDbContext _context;

        public ModelRepository(WebAppRentSysDbContext currentContext)
        {
            this._context = currentContext;
        }

        public List<Model> GetAll()
        {
            return _context.Models.ToList();
        }

        public Model GetByID(int id)
        {
            return _context.Models.Find(id);
        }

        public void Add(Model item)
        {
            _context.Models.Add(item);
        }

        public void Delete(int id)
        {
            Model model = _context.Models.Find(id);
            _context.Models.Remove(model);
        }

        public void Update(Model item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
