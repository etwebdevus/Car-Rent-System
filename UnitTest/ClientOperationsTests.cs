using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLayerClassLibrary.Entities;
using ModelLayerClassLibrary.Abstract;
using ModelLayerClassLibrary.Utils;
using ModelLayerClassLibrary.Enum;
using System.Linq;
using ModelLayerClassLibrary.Repositories;

namespace UnitTest
{
    [TestClass]
    public class ClientOperationsTests
    {
        [TestMethod]
        public void ClientInstanceTest()
        {
            //Arrange
            string NameExp = "Hartur";
            Address AddressExp = new Address { City = "Recife", State = EnumState.PE, Number = 233 };
            string EmailExp = "hbb@ecomp.poli.br";
            PhoneNumber PhoneNumberExp = new PhoneNumber { DDD = "81", Phone = "92471119" };
            string IDNumberExp = "05973361217";
            CreditCard CreditCardExp = new CreditCard{Month = 12, Year = 2016, Name = "HARTUR", Number = "456456456", SecurityNumber = "555"};
            bool IsIndividualExp = true;

            //Act
            Client found = new Client
            {
                Name = NameExp,
                Address = AddressExp,
                Email = EmailExp,
                PhoneNumber = PhoneNumberExp,
                CreditCard = CreditCardExp,
                IDNumber = IDNumberExp,
                IsIndividual = IsIndividualExp
            };

            //Assert
            Assert.AreEqual(NameExp, found.Name);
            Assert.AreEqual(AddressExp, found.Address);
            Assert.AreEqual(PhoneNumberExp, found.PhoneNumber);
            Assert.AreEqual(CreditCardExp, found.CreditCard);
        }


        [TestMethod]
        public void ClientRepositoryAddTest()
        {
            //Arrange
            string NameExp = "Eduardo";
            Address AddressExp = new Address { City = "Recife", State = EnumState.PE, Number = 233 };
            string EmailExp = "ebb2@cin.ufpe.br";
            PhoneNumber PhoneNumberExp = new PhoneNumber { DDD = "81", Phone = "92471119" };
            string IDNumberExp = "05973361217";
            CreditCard CreditCardExp = new CreditCard{Month = 12, Year = 2016, Name = "HARTUR", Number = "456456456", SecurityNumber = "555"};
            bool IsIndividualExp = true;

            Client client = new Client
            {
                Name = NameExp,
                Address = AddressExp,
                Email = EmailExp,
                PhoneNumber = PhoneNumberExp,
                CreditCard = CreditCardExp,
                IDNumber = IDNumberExp,
                IsIndividual = IsIndividualExp
            };

            using (UserRepository userRepo = new UserRepository(new WebAppRentSysDbContext()))
            {
                //Act
                userRepo.Add(client);
                userRepo.Save();

                //Assert
                Assert.AreEqual(userRepo.GetAll().FirstOrDefault(x => x.Name == NameExp), client);
            }
        }

        [TestMethod]
        public void ClientRepositoryUpdateTest()
        {
            using (UserRepository userRepo = new UserRepository(new WebAppRentSysDbContext()))
            {
                //Arrange
                Client client = userRepo.GetAll().OfType<Client>().FirstOrDefault(x => x.Name == "Eduardo");
                client.Name = "Eduardo Barreto Brito";
            
                //Act
                userRepo.Update(client);
                userRepo.Save();

                //Assert
                Assert.AreEqual(userRepo.GetAll().FirstOrDefault(x => x.Name == "Eduardo Barreto Brito"), client);
            }
        }

        [TestMethod]
        public void ClientRepositoryDeleteTest()
        {
            using (UserRepository userRepo = new UserRepository(new WebAppRentSysDbContext()))
            {
                //Arrange
                Client client = userRepo.GetAll().OfType<Client>().FirstOrDefault(x => x.Name == "Eduardo Barreto Brito");

                //Act
                userRepo.Delete(client.UserID);
                userRepo.Save();

                //Assert
                Assert.AreEqual(userRepo.GetAll().FirstOrDefault(x => x.Name == "Eduardo Barreto Brito"), null);
            }
        }
    }
}
