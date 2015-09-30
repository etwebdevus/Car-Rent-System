using ModelLayerClassLibrary.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayerClassLibrary.Entities
{
    public interface IWebAppRentSysDbContext : IDisposable
    {
        DbSet<Manufacturer> Manufacturers { get; set; }
        DbSet<Model> Models { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Car> Cars { get; set; }
        DbSet<Rent> Rents { get; set; }

        int SaveChanges();
        void OnModelCreating(DbModelBuilder modelBuilder);
    }
}
