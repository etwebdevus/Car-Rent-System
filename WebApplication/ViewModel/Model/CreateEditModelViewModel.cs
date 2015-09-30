using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ModelLayerClassLibrary.Entities;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using UtilsValidation.Model;
using ModelLayerClassLibrary.Enum;

namespace WebApplication.ViewModel.Model
{
    public class CreateEditModelViewModel
    {
        public int ModelID { get; set; }

        [Required]
        [Name]
        [Display(Name = "Model")]
        public string Name { get; set; }
        [Required]
        [Range(0.5,4)]
        public double Engine { get; set; }
        [Required]
        public EnumCategory Category { get; set; }
        [Required]
        public int ManufacturerID { get; set; }

        public SelectList Manufacturers { get; set; }
    }
}