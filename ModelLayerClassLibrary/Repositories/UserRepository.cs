using ModelLayerClassLibrary.Abstract;
using ModelLayerClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayerClassLibrary.Repositories
{
    public class UserRepository : IRepository<User>
    {

        private WebAppRentSysDbContext _context;

        public UserRepository(WebAppRentSysDbContext currentContext)
        {
            this._context = currentContext;
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetByID(int id)
        {
            return _context.Users.Find(id);
        }

        public void Add(User item)
        {
            _context.Users.Add(item);
        }

        public void Delete(int id)
        {
            User user = _context.Users.Find(id);
            _context.Users.Remove(user);
        }

        public void Update(User item)
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
