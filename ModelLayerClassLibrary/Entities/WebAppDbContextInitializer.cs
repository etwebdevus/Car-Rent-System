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
                Category = EnumCategory.Economy
            });

            rentSys.Models.Add(new Model
            {
                Name = "Uno",
                Engine = 1.4,
                ManufacturerID = 5,
                Category = EnumCategory.Intermediate
            });

            rentSys.Models.Add(new Model
            {
                Name = "Bravo",
                Engine = 2,
                ManufacturerID = 5,
                Category = EnumCategory.Premium
            });

            rentSys.Models.Add(new Model
            {
                Name = "Freemont",
                Engine = 1,
                ManufacturerID = 5,
                Category = EnumCategory.SUV
            });

            rentSys.Models.Add(new Model
            {
                Name = "Renegade",
                Engine = 2,
                ManufacturerID = 4,
                Category = EnumCategory.OffRoad
            });
            
            rentSys.Models.Add(new Model
            {
                Name = "Cherokee",
                Engine = 2,
                ManufacturerID = 4,
                Category = EnumCategory.SUV
            });

            rentSys.Models.Add(new Model
            {
                Name = "Onix",
                Engine = 1.4,
                ManufacturerID = 3,
                Category = EnumCategory.Intermediate
            });

            rentSys.Models.Add(new Model
            {
                Name = "S10",
                Engine = 2,
                ManufacturerID = 3,
                Category = EnumCategory.OffRoad
            });

            rentSys.Models.Add(new Model
            {
                Name = "Ka",
                Engine = 1.5,
                ManufacturerID = 2,
                Category = EnumCategory.Intermediate
            });

            rentSys.Models.Add(new Model
            {
                Name = "New Fiesta",
                Engine = 1.5,
                ManufacturerID = 2,
                Category = EnumCategory.Intermediate
            });

            rentSys.Models.Add(new Model
            {
                Name = "New Fiesta",
                Engine = 2,
                ManufacturerID = 2,
                Category = EnumCategory.Premium
            });

            rentSys.Models.Add(new Model
            {
                Name = "Gol",
                Engine = 1,
                ManufacturerID = 1,
                Category = EnumCategory.Economy
            });

            rentSys.Models.Add(new Model
            {
                Name = "Jetta",
                Engine = 2,
                ManufacturerID = 1,
                Category = EnumCategory.Premium
            });

            rentSys.Models.Add(new Model
            {
                Name = "Amarok",
                Engine = 2,
                ManufacturerID = 1,
                Category = EnumCategory.OffRoad
            });

            rentSys.SaveChanges();

            //------------CARS INITIALIZE------------//
            rentSys.Cars.Add(new Car
            {
                CarColor = EnumColor.Black,
                LicensePlate = "qwe1234",
                ModelID = 1,
                Price = 50
            });

            rentSys.Cars.Add(new Car
            {
                CarColor = EnumColor.White,
                LicensePlate = "qwe1235",
                ModelID = 2,
                Price = 50
            });

            rentSys.Cars.Add(new Car
            {
                CarColor = EnumColor.Gray,
                LicensePlate = "qwe1236",
                ModelID = 3,
                Price = 70
            });

            rentSys.Cars.Add(new Car
            {
                CarColor = EnumColor.Black,
                LicensePlate = "qwe1237",
                ModelID = 4,
                Price = 100
            });

            rentSys.Cars.Add(new Car
            {
                CarColor = EnumColor.Brown,
                LicensePlate = "qwe1238",
                ModelID = 5,
                Price = 120
            });

            rentSys.Cars.Add(new Car
            {
                CarColor = EnumColor.Red,
                LicensePlate = "qwe1239",
                ModelID = 7,
                Price = 100
            });

            rentSys.Cars.Add(new Car
            {
                CarColor = EnumColor.White,
                LicensePlate = "qwe1214",
                ModelID = 8,
                Price = 50
            });

            rentSys.SaveChanges();

            //------------CLIENTS INITIALIZE------------//
            rentSys.Users.Add(new Client
            {
                Name = "Hartur",
                Address = new Address { City = "Recife", State = EnumState.PE, Number = 233, Street = "Falcão de Lacerda", District = "Tejipió" },
                Email = "hbb@ecomp.poli.br",
                PhoneNumber = new PhoneNumber { DDD = "81", Phone = "92471119" },
                CreditCard = new CreditCard{Month = 12, Year = 2016, Name = "HARTUR", Number = "4564564564564564", SecurityNumber = "555"},
                IsIndividual = true,
                IDNumber = "21919065679"
            });

            rentSys.Users.Add(new Client
            {
                Name = "Eduardo",
                Address = new Address { City = "Recife", State = EnumState.PE, Number = 233, Street = "Falcão de Lacerda", District = "Tejipió" },
                Email = "ebb2@cin.ufpe.br",
                PhoneNumber = new PhoneNumber { DDD = "81", Phone = "82432149" },
                CreditCard = new CreditCard { Month = 12, Year = 2016, Name = "EDUARDO", Number = "4564564564564564", SecurityNumber = "555" },
                IsIndividual = true,
                IDNumber = "73521635570",
            });

            rentSys.Users.Add(new Client
            {
                Name = "Henrique",
                Address = new Address { City = "Recife", State = EnumState.PE, Number = 300, Street = "Democrito de Souza Filho", District = "Madalena" },
                Email = "hpcs@ecomp.poli.br",
                PhoneNumber = new PhoneNumber { DDD = "81", Phone = "96461312" },
                CreditCard = new CreditCard { Month = 12, Year = 2016, Name = "HENRIQUE", Number = "4564564564564564", SecurityNumber = "555" },
                IsIndividual = true,
                IDNumber = "43148833678"
            });

            rentSys.SaveChanges();
            //------------RENTS INITIALIZE------------//
            rentSys.Rents.Add(new Rent
                {
                    CarID = 7,
                    UserID = 2,
                    PickupDate = new DateTime(2015,09,27),
                    ReturnDate = new DateTime(2015,09,28),
                    Price = 200
                });

            rentSys.Rents.Add(new Rent
            {
                CarID = 2,
                UserID = 3,
                PickupDate = new DateTime(2015, 09, 27),
                ReturnDate = new DateTime(2015, 10, 10),
                Price = 200
            });

            rentSys.Rents.Add(new Rent
            {
                CarID = 4,
                UserID = 1,
                PickupDate = new DateTime(2015, 09, 27),
                ReturnDate = new DateTime(2015, 09, 30),
                Price = 300
            });

            rentSys.SaveChanges();

            base.Seed(rentSys);
        }
    }
}
