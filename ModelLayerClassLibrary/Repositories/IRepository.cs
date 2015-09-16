using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayerClassLibrary.Repositories
{
    public interface IRepository<T> : IDisposable
    {
        List<T> GetAll();
        T GetByID(int id);
        void Add(T item);
        void Delete(int id);
        void Update(T item);
        void Save();
    }
}