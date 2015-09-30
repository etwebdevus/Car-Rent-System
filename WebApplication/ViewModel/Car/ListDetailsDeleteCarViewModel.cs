using ModelLayerClassLibrary.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UtilsValidation.Car;

namespace WebApplication.ViewModel.Car
{
    public class ListDetailsDeleteCarViewModel
    {
        public int CarID { get; set; }
        [Display(Name = "License Plate")]
        [LicensePlateVal]
        public string LicensePlate { get; set; }
        [Display(Name = "Color")]
        public EnumColor CarColor { get; set; }
        [Display(Name = "Price (R$)")]
        [PriceVal]
        public decimal Price { get; set; }
        [Display(Name = "Model")]
        public string ModelName { get; set; }
        [Display(Name = "Engine")]
        public string ModelEngine { get; set; }
        [Display(Name = "Manufacturer")]
        public string ManufacturerName { get; set; }
    }
}