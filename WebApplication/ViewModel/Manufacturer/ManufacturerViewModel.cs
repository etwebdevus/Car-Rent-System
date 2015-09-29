using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UtilsValidation.Manufacturer;

namespace WebApplication.ViewModel.Manufacturer
{
    public class ManufacturerViewModel
    {
        public int ManufacturerID { get; set; }
        [Display(Name = "Manufacturer")]
        [Name]
        public string Name { get; set; }
    }
}