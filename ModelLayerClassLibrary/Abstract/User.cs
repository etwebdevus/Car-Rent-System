using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayerClassLibrary.Utils;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace ModelLayerClassLibrary.Abstract
{
    public abstract class User
    {
        public int UserID { get; set; }
        [Display(Name = "Is individual")]
        public bool IsIndividual { get; set; }
        public string Name { get; set; }
        [Display(Name = "ID Number")]
        public string IDNumber { get; set; }
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Display(Name = "Phone Number")]
        public PhoneNumber PhoneNumber { get; set; }
        public Address Address { get; set; }  
    }
}
