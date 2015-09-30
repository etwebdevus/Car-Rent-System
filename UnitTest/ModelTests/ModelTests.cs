using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLayerClassLibrary.Entities;
using ModelLayerClassLibrary.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.ManufacturerTests
{
    [TestClass]
    public class ModelTests
    {
        [TestMethod]
        public void ModelInstance()
        {
            //Arrange
            string manufacturerNameEx = "NewManufacturer";
            Manufacturer manuEx = new Manufacturer { Name = manufacturerNameEx };
            string modelNameEx = "NewModel";
            double engineEx = 2;
            EnumCategory catEx = EnumCategory.Intermediate;

            //Act
            Model found = new Model { Name = modelNameEx, Manufacturer = manuEx, Engine = engineEx, Category = catEx };

            //Assert
            Assert.AreEqual(modelNameEx, found.Name);
            Assert.AreEqual(engineEx, found.Engine);
            Assert.AreEqual(catEx, found.Category);
            Assert.AreEqual(manufacturerNameEx, found.Manufacturer.Name);
        }
    }
}
