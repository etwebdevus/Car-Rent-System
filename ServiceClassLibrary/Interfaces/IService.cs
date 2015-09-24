using ModelLayerClassLibrary.Abstract;
using ModelLayerClassLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClassLibrary.Interfaces
{
    public interface IService<T> : IRepository<T>
    {
    }
}
