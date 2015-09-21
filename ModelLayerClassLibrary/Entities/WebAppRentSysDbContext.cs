using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayerClassLibrary.Abstract;

namespace ModelLayerClassLibrary.Entities
{
    public class WebAppRentSysDbContext : DbContext
    {
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Rent> Rents { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>().ToTable("Clients");

            modelBuilder.Entity<Manufacturer>().HasMany<Model>(t => t.Models).WithRequired(t => t.Manufacturer).HasForeignKey(t => t.ManufacturerID).WillCascadeOnDelete(true);
        }

        public System.Data.Entity.DbSet<ModelLayerClassLibrary.Entities.Client> Clients { get; set; }
    }
}
