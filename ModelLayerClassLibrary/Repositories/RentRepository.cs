using ModelLayerClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayerClassLibrary.Repositories
{
    public class RentRepository : IRepository<Rent>
    {
        private WebAppRentSysDbContext _context;

        public RentRepository(WebAppRentSysDbContext currentContext)
        {
            this._context = currentContext;
        }

        public List<Rent> GetAll()
        {
            return _context.Rents.ToList();
        }

        public Rent GetByID(int id)
        {
            return _context.Rents.Find(id);
        }

        public void Add(Rent item)
        {
            _context.Rents.Add(item);
        }

        public void Delete(int id)
        {
            Rent rent = _context.Rents.Find(id);
            _context.Rents.Remove(rent);
        }

        public void Update(Rent item)
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
