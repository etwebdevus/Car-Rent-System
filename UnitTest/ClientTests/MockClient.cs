using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using ServiceClassLibrary.Interfaces;
using ModelLayerClassLibrary.Abstract;
using ModelLayerClassLibrary.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLayerClassLibrary.Utils;
using ModelLayerClassLibrary.Entities;
using ModelLayerClassLibrary.Enum;

namespace UnitTest.ClientTests
{
    
    public class MockClient
    {

        Mock ClientMockRepo = new Mock<IRepository<User>>();

        public void Configure()
        {
            List<User> Users = new List<User>();

            Users.Add(new Client
            {
                Name = "Hartur",
                Address = new Address { City = "Recife", State = EnumState.PE, Number = 233, Street = "Falcão de Lacerda", District = "Tejipió" },
                Email = "hbb@ecomp.poli.br",
                PhoneNumber = new PhoneNumber { DDD = "81", Phone = "92471119" },
                CreditCard = new CreditCard{Month = 12, Year = 2016, Name = "HARTUR", Number = "4564564564564564", SecurityNumber = "555"},
                IsIndividual = true,
                IDNumber = "21919065679"
            });

            Users.Add(new Client
            {
                Name = "Eduardo",
                Address = new Address { City = "Recife", State = EnumState.PE, Number = 233, Street = "Falcão de Lacerda", District = "Tejipió" },
                Email = "ebb2@cin.ufpe.br",
                PhoneNumber = new PhoneNumber { DDD = "81", Phone = "82432149" },
                CreditCard = new CreditCard { Month = 12, Year = 2016, Name = "EDUARDO", Number = "4564564564564564", SecurityNumber = "555" },
                IsIndividual = true,
                IDNumber = "73521635570",
            });

            Users.Add(new Client
            {
                Name = "Henrique",
                Address = new Address { City = "Recife", State = EnumState.PE, Number = 300, Street = "Democrito de Souza Filho", District = "Madalena" },
                Email = "hpcs@ecomp.poli.br",
                PhoneNumber = new PhoneNumber { DDD = "81", Phone = "96461312" },
                CreditCard = new CreditCard { Month = 12, Year = 2016, Name = "HENRIQUE", Number = "4564564564564564", SecurityNumber = "555" },
                IsIndividual = true,
                IDNumber = "43148833678"
            });

            //ClientMockRepo.Setup(x => x.GetAll()).Returns(Users);
        }
    }
}
