using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLayerClassLibrary.Utils;
using ModelLayerClassLibrary.Entities;
using ModelLayerClassLibrary.Enum;
using ModelLayerClassLibrary.Repositories;

namespace UnitTest.ClientsTests
{
    [TestClass]
    public class ClientTests
    {
        [TestMethod]
        public void ClientInstance()
        {
            //Arrange
            string NameInput = "Hartur";
            string NameOutput = NameInput.ToUpper();

            string IDNumberInput = "445.266.834-85";
            string IDNumberOutput = IDNumberInput.Replace(".", "").Replace("-", "");

            Address AddressExp = new Address { Street = "Rua Falcão de Lacerda", District = "Tejipió", City = "Recife", State = EnumState.PE, Number = 233 };
            string EmailExp = "hbb@ecomp.poli.br";
            
            PhoneNumber PhoneNumberInput = new PhoneNumber { DDD = "(81)", Phone = "9247 1119" };
            PhoneNumber PhoneNumberOutput = new PhoneNumber { DDD = "81", Phone = "92471119" };

            CreditCard CreditCardExp = new CreditCard { Month = 12, Year = 2016, Name = "HARTUR", Number = "4564564564564564", SecurityNumber = "555" };
            
            bool IsIndividualExp = true;

            //Act
            Client found = new Client
            {
                Name = NameInput,
                Address = AddressExp,
                Email = EmailExp,
                PhoneNumber = PhoneNumberInput,
                CreditCard = CreditCardExp,
                IDNumber = IDNumberInput,
                IsIndividual = IsIndividualExp
            };

            //Assert
            Assert.AreEqual(NameOutput, found.Name);
            Assert.AreEqual(IDNumberOutput, found.IDNumber);
            Assert.AreEqual(PhoneNumberOutput.DDD, found.PhoneNumber.DDD);
            Assert.AreEqual(PhoneNumberOutput.Phone, found.PhoneNumber.Phone);
        }

        //[TestMethod]
        //public void ClientRepositoryAdd()
        //{
        //    //Arrange
        //    string NameInput = "Hartur";
        //    string NameOutput = NameInput.ToUpper();

        //    string IDNumberInput = "445.266.834-85";
        //    string IDNumberOutput = IDNumberInput.Replace(".", "").Replace("-", "");

        //    Address AddressExp = new Address { Street = "Rua Falcão de Lacerda", District = "Tejipió", City = "Recife", State = EnumState.PE, Number = 233 };
        //    string EmailExp = "hbb@ecomp.poli.br";

        //    PhoneNumber PhoneNumberInput = new PhoneNumber { DDD = "(81)", Phone = "9247 1119" };
        //    PhoneNumber PhoneNumberOutput = new PhoneNumber { DDD = "81", Phone = "92471119" };

        //    CreditCard CreditCardExp = new CreditCard { Month = 12, Year = 2016, Name = "HARTUR", Number = "4564564564564564", SecurityNumber = "555" };

        //    bool IsIndividualExp = true;

        //    Client clientEx = new Client
        //    {
        //        Name = NameInput,
        //        Address = AddressExp,
        //        Email = EmailExp,
        //        PhoneNumber = PhoneNumberInput,
        //        CreditCard = CreditCardExp,
        //        IDNumber = IDNumberInput,
        //        IsIndividual = IsIndividualExp
        //    };

        //    //Act
        //    using (UserRepository userRepo = new UserRepository(new WebAppRentSysDbContext()))
        //    {
        //        userRepo.Add(clientEx);
        //    }
            
        //}
    }
}
