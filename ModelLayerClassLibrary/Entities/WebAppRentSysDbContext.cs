using ModelLayerClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayerClassLibrary.Abstract;

namespace ModelLayerClassLibrary.Entities
{
    public class WebAppRentSysDbContext : DbContext, IWebAppRentSysDbContext
    {
        public IDbSet<IManufacturer> Manufacturers { get; set; }
        public IDbSet<IModel> Models { get; set; }
        public IDbSet<IUser> Clients { get; set; }
        public IDbSet<ICar> Cars { get; set; }
        public IDbSet<IRent> Rents { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Database.SetInitializer<WebAppRentSysDbContext>(new WebAppDbContextInitializer());

            modelBuilder.Entity<IManufacturer>().HasMany<IModel>(t => t.Models).WithRequired(t => t.Manufacturer).HasForeignKey(t => t.ManufacturerID).WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>().ToTable("Clients");

        }
    }
}
