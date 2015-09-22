using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.ViewModel.Model
{
    public class ListDetailsDeleteModelViewModel
    {
        public int ModelID { get; set; }
        [Required]
        [MaxLength(20)]
        [Display(Name = "Model")]
        public string Name { get; set; }
        [Required]
        [Range(0.5, 4)]
        public double Engine { get; set; }
        [Required]
        public int Category { get; set; }
        [Required]
        public int ManufacturerID { get; set; }
        public string ManufacturerName { get; set; }
    }
}