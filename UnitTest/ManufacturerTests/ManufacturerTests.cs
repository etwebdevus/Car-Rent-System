using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLayerClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.ManufacturerTests
{
    [TestClass]
    public class ManufacturerTests
    {
        [TestMethod]
        public void ManufacturerInstance()
        {
            //Arrange
            string nameEx = "NewManufacturer";

            //Act
            Manufacturer found = new Manufacturer { Name = nameEx };

            //Assert
            Assert.AreEqual(nameEx, found.Name);
        }
    }
}
