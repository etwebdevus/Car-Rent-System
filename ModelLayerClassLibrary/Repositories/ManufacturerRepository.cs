using ModelLayerClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayerClassLibrary.Repositories
{
    public class ManufacturerRepository : IRepository<Manufacturer>
    {
        private WebAppRentSysDbContext _context;

        public ManufacturerRepository(WebAppRentSysDbContext currentContext)
        {
            this._context = currentContext;
        }

        public List<Manufacturer> GetAll()
        {
            return _context.Manufacturers.ToList();
        }

        public Manufacturer GetByID(int id)
        {
            return _context.Manufacturers.Find(id);
        }

        public void Add(Manufacturer item)
        {
            _context.Manufacturers.Add(item);
        }

        public void Delete(int id)
        {
            Manufacturer manufacturer = _context.Manufacturers.Find(id);
            _context.Manufacturers.Remove(manufacturer);
        }

        public void Update(Manufacturer item)
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
