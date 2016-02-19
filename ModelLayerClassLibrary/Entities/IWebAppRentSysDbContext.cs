using ModelLayerClassLibrary.Abstract;
using System;
using System.Data.Entity;

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
