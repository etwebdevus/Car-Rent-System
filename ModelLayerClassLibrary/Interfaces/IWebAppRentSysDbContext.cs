using ModelLayerClassLibrary.Abstract;
using ModelLayerClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayerClassLibrary.Interfaces
{
    public interface IWebAppRentSysDbContext : IDisposable
    {
        IDbSet<IManufacturer> Manufacturers { get; set; }
        IDbSet<IModel> Models { get; set; }
        IDbSet<IUser> Clients { get; set; }
        IDbSet<ICar> Cars { get; set; }
        IDbSet<IRent> Rents { get; set; }
    }
}
