using ModelLayerClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayerClassLibrary.Repositories
{
    public class CarRepository : IRepository<Car>
    {
        private WebAppRentSysDbContext _context;

        public CarRepository(WebAppRentSysDbContext currentContext)
        {
            this._context = currentContext;
        }

        public List<Car> GetAll()
        {
            return _context.Cars.ToList();
        }

        public Car GetByID(int id)
        {
            return _context.Cars.Find(id);
        }

        public void Add(Car item)
        {
            _context.Cars.Add(item);
        }

        public void Delete(int id)
        {
            Car car = _context.Cars.Find(id);
            _context.Cars.Remove(car);
        }

        public void Update(Car item)
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
