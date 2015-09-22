using ModelLayerClassLibrary.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.ViewModel.Car
{
    public class CreateEditCarViewModel
    {
        public int CarID { get; set; }
        [Display(Name = "License Plate")]
        public string LicensePlate { get; set; }
        [Display(Name = "Color")]
        public EnumColor CarColor { get; set; }
        public string ModelID { get; set; }
        public string ManufacturerID { get; set; }

        public SelectList Manufacturers { get; set; }
        public SelectList Models { get; set; }
    }
}