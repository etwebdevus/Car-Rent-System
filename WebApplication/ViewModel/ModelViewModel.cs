using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ModelLayerClassLibrary.Entities;
using System.Web.Mvc;

namespace WebApplication.ViewModel
{
    public class ModelViewModel
    {
        public int ModelID { get; set; }
        public string Name { get; set; }
        public double Engine { get; set; }
        public int Category { get; set; }

        public int ManufacturerID { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }

        public SelectList Manufacturers { get; set; }
    }
}