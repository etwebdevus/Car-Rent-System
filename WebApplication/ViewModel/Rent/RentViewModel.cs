using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.ViewModel.Car;
using WebApplication.ViewModel.Client;

namespace WebApplication.ViewModel.Rent
{
    public class RentViewModel
    {
        [Display(Name="Search for")]
        public string searchString { get; set; }

        public int RentID { get; set; }
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Display(Name = "Car")]
        public int CarID { get; set; }
        [Display(Name = "Manufacturer")]
        public string ManufacturerName { get; set; }
        [Display(Name = "Model")]
        public string ModelName { get; set; }
        [Display(Name = "Engine")]
        public string ModelEngine { get; set; }

        [Display(Name = "User")]
        public int UserID { get; set; }
        [Display(Name = "User")]
        public string UserName { get; set; }

        [Display(Name = "Days")]
        [Required]
        [Range(1,360)]
        public int Days { get; set; }
        [Display(Name = "Pickup")]
        public string PickupDate { get; set; }
        [Display(Name = "Return")]
        public string ReturnDate { get; set; }

        [Display(Name = "Car")]
        public List<ListDetailsDeleteCarViewModel> CarList;
        [Display(Name = "User")]
        public List<ClientViewModel> UserList;
    }
}