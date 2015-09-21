using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayerClassLibrary.Utils;
using ModelLayerClassLibrary.Enum;

namespace ModelLayerClassLibrary.Entities
{
    public class WebAppDbContextInitializer : DropCreateDatabaseAlways<WebAppRentSysDbContext>
    {
        protected override void Seed(WebAppRentSysDbContext rentSys)
        {
            //------------MANUFACTURERS INITIALIZE------------//
            rentSys.Manufacturers.Add(new Manufacturer{
                Name = "Volkswagem",
                Models = new List<Model>()
            });

            rentSys.Manufacturers.Add(new Manufacturer
            {
                Name = "Ford",
                Models = new List<Model>()
            });

            rentSys.Manufacturers.Add(new Manufacturer
            {
                Name = "Chevrolet",
                Models = new List<Model>()
            });

            rentSys.Manufacturers.Add(new Manufacturer
            {
                Name = "Jeep",
                Models = new List<Model>()
            });

            rentSys.Manufacturers.Add(new Manufacturer
            {
                Name = "Fiat",
                Models = new List<Model>()
            });

            rentSys.SaveChanges();

            //------------MODELS INITIALIZE------------//
            rentSys.Models.Add(new Model
            {
                Name = "Uno",
                Engine = 1,
                ManufacturerID = 5,
                Category = 2
            });

            rentSys.Models.Add(new Model
            {
                Name = "Uno",
                Engine = 1.4,
                ManufacturerID = 5,
                Category = 8
            });

            rentSys.Models.Add(new Model
            {
                Name = "Bravo",
                Engine = 2,
                ManufacturerID = 5,
                Category = 32
            });

            rentSys.Models.Add(new Model
            {
                Name = "Freemont",
                Engine = 1,
                ManufacturerID = 5,
                Category = 48
            });

            rentSys.Models.Add(new Model
            {
                Name = "Renegade",
                Engine = 2,
                ManufacturerID = 4,
                Category = 144
            });
            
            rentSys.Models.Add(new Model
            {
                Name = "Cherokee",
                Engine = 2,
                ManufacturerID = 4,
                Category = 48
            });

            rentSys.Models.Add(new Model
            {
                Name = "Onix",
                Engine = 1.4,
                ManufacturerID = 3,
                Category = 6
            });

            rentSys.Models.Add(new Model
            {
                Name = "S10",
                Engine = 2,
                ManufacturerID = 3,
                Category = 128
            });

            rentSys.Models.Add(new Model
            {
                Name = "Ka",
                Engine = 1.5,
                ManufacturerID = 2,
                Category = 6
            });

            rentSys.Models.Add(new Model
            {
                Name = "New Fiesta",
                Engine = 1.5,
                ManufacturerID = 2,
                Category = 6
            });

            rentSys.Models.Add(new Model
            {
                Name = "New Fiesta",
                Engine = 2,
                ManufacturerID = 2,
                Category = 32
            });

            rentSys.Models.Add(new Model
            {
                Name = "Gol",
                Engine = 1,
                ManufacturerID = 1,
                Category = 2
            });

            rentSys.Models.Add(new Model
            {
                Name = "Jetta",
                Engine = 2,
                ManufacturerID = 1,
                Category = 32
            });

            rentSys.Models.Add(new Model
            {
                Name = "Amarok",
                Engine = 2,
                ManufacturerID = 1,
                Category = 160
            });

            rentSys.SaveChanges();

            //------------CARS INITIALIZE------------//
            rentSys.Cars.Add(new Car
            {
                CarColor = EnumColor.Black,
                LicensePlate = "qwe1234",
                ModelID = 1
            });

            rentSys.Cars.Add(new Car
            {
                CarColor = EnumColor.White,
                LicensePlate = "qwe1235",
                ModelID = 2
            });

            rentSys.Cars.Add(new Car
            {
                CarColor = EnumColor.Gray,
                LicensePlate = "qwe1236",
                ModelID = 3
            });

            rentSys.Cars.Add(new Car
            {
                CarColor = EnumColor.Black,
                LicensePlate = "qwe1237",
                ModelID = 4
            });

            rentSys.Cars.Add(new Car
            {
                CarColor = EnumColor.Brown,
                LicensePlate = "qwe1238",
                ModelID = 5
            });

            rentSys.Cars.Add(new Car
            {
                CarColor = EnumColor.Red,
                LicensePlate = "qwe1239",
                ModelID = 7
            });

            rentSys.Cars.Add(new Car
            {
                CarColor = EnumColor.White,
                LicensePlate = "qwe1214",
                ModelID = 8
            });

            rentSys.SaveChanges();

            //------------CLIENTS INITIALIZE------------//
            rentSys.Users.Add(new Client
            {
                Name = "Hartur",
                Address = new Address { City = "Recife", State = EnumState.PE, Number = 233, Street = "Falcão de Lacerda", District = "Tejipió" },
                Email = "hbb@ecomp.poli.br",
                PhoneNumber = new PhoneNumber { DDD = "81", Phone = "92471119" },
                CreditCard = new CreditCard{Month = 12, Year = 2016, Name = "HARTUR", Number = "456456456", SecurityNumber = "555"},
                IDNumber = "21919065679",
                IsIndividual = true
            });

            rentSys.Users.Add(new Client
            {
                Name = "Eduardo",
                Address = new Address { City = "Recife", State = EnumState.PE, Number = 233, Street = "Falcão de Lacerda", District = "Tejipió" },
                Email = "ebb2@cin.ufpe.br",
                PhoneNumber = new PhoneNumber { DDD = "81", Phone = "82432149" },
                CreditCard = new CreditCard { Month = 12, Year = 2016, Name = "EDUARDO", Number = "456456456", SecurityNumber = "555" },
                IDNumber = "73521635570",
                IsIndividual = true
            });

            rentSys.Users.Add(new Client
            {
                Name = "Henrique",
                Address = new Address { City = "Recife", State = EnumState.PE, Number = 300, Street = "Democrito de Souza Filho", District = "Madalena" },
                Email = "hpcs@ecomp.poli.br",
                PhoneNumber = new PhoneNumber { DDD = "81", Phone = "96461312" },
                CreditCard = new CreditCard { Month = 12, Year = 2016, Name = "HENRIQUE", Number = "456456456", SecurityNumber = "555" },
                IDNumber = "43148833678",
                IsIndividual = true
            });

            rentSys.SaveChanges();

            base.Seed(rentSys);
        }
    }
}
