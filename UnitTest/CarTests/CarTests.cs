using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLayerClassLibrary.Entities;
using ModelLayerClassLibrary.Enum;

namespace UnitTest.CarTests
{
    /// <summary>
    /// Summary description for CarTests
    /// </summary>
    [TestClass]
    public class CarTests
    {
        [TestMethod]
        public void CarInstance()
        {
            //Arrange
            string manufacturerNameEx = "NewManufacturer";
            Manufacturer manuEx = new Manufacturer { Name = manufacturerNameEx };
            string modelNameEx = "NewModel";
            double engineEx = 2;
            EnumCategory catEx = EnumCategory.Intermediate;
            Model model = new Model { Name = modelNameEx, Manufacturer = manuEx, Engine = engineEx, Category = catEx };
            EnumColor colorEx = EnumColor.White;
            string plateEx = "qwe1234";
            decimal priceEx = 50;

            //Act
            Car found = new Car
            {
                CarColor = colorEx,
                LicensePlate = plateEx,
                Model = model,
                Price = priceEx
            };

            //Assert
            Assert.AreEqual(colorEx, found.CarColor);
            Assert.AreEqual(plateEx, found.LicensePlate);
            Assert.AreEqual(priceEx, found.Price);
        }
    }
}
