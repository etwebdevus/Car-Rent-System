using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLayerClassLibrary.Entities;
using ModelLayerClassLibrary.Abstract;
using ModelLayerClassLibrary.Utils;
using ModelLayerClassLibrary.Enum;
using System.Linq;

namespace UnitTest
{
    [TestClass]
    public class EntitiesTest
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
            string CreditCardExp = "45645465";
            bool IsIndividualExp = true;

            //Act
            Client found = new Client
            {
                UserID = 1,
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
        public void DbContextTest()
        {
            //Arrange
            string NameExp = "Hartur";
            Address AddressExp = new Address { City = "Recife", State = EnumState.PE, Number = 233 };
            string EmailExp = "hbb@ecomp.poli.br";
            PhoneNumber PhoneNumberExp = new PhoneNumber { DDD = "81", Phone = "92471119" };
            string IDNumberExp = "05973361217";
            string CreditCardExp = "45645465";
            bool IsIndividualExp = true;

            User client = new Client
            {
                Name = NameExp,
                Address = AddressExp,
                Email = EmailExp,
                PhoneNumber = PhoneNumberExp,
                CreditCard = CreditCardExp,
                IDNumber = IDNumberExp,
                IsIndividual = IsIndividualExp
            };

            //Act
            using (WebAppRentSysDbContext rentSysDbContext = new WebAppRentSysDbContext())
            {
                rentSysDbContext.Clients.Add(client);
                rentSysDbContext.SaveChanges();

            //Assert
                Client found = rentSysDbContext.Clients.OfType<Client>().FirstOrDefault(t => t.Name == "Hartur");
                Assert.AreEqual(NameExp, found.Name);
            }
        }
    }
}
