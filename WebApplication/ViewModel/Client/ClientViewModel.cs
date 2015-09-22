using ModelLayerClassLibrary.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.ViewModel.Client
{
    public class ClientViewModel
    {
        public int UserID { get; set; }

        [Required]
        [Display(Name = "Is individual")]
        public bool IsIndividual { get; set; }
        
        [Required]
        //[MinLength(3)]
        //[MaxLength(26)]
        public string Name { get; set; }
        
        [Required]
        [Display(Name = "ID Number")]
        //[StringLength(11)]
        public string IDNumber { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        //[DataType(DataType.EmailAddress)]
        //[MinLength(5)]
        //[MaxLength(26)]
        public string Email { get; set; }


        [Required]
        [Display(Name = "Phone Number")]
        //[StringLength(3)]
        public string PhoneNumberDDD { get; set; }
        
        [Required]
        //[MinLength(8)]
        //[MaxLength(9)]
        public string PhoneNumberPhone { get; set; }

        
        [Required]
        [Display(Name = "State")]
        public EnumState AddressState { get; set; }
        
        [Required]
        [Display(Name = "City")]
        //[MinLength(2)]
        //[MaxLength(26)]
        public string AddressCity { get; set; }
        
        [Required]
        [Display(Name = "Street")]
        //[MinLength(2)]
        //[MaxLength(26)]
        public string AddressStreet { get; set; }
        
        [Required]
        [Display(Name = "District")]
        //[MinLength(3)]
        //[MaxLength(26)]
        public string AddressDistrict { get; set; }
        
        [Required]
        [Display(Name = "Address Number")]
        //[MinLength(1)]
        //[MaxLength(5)]
        public int AddressNumber { get; set; }

        [Required]
        [Display(Name = "Credit Card's owner name")]
        //[DataType(DataType.Text)]
        //[MinLength(2)]
        //[MaxLength(26)]
        public string CreditCardName { get; set; }

        [Required]
        [Display(Name = "Credit Card Number")]
        //[StringLength(16)]
        public string CreditCardNumber { get; set; }

        [Required]
        [Display(Name = "Credit Card Security Number")]
        //[StringLength(3)]
        public string CreditCardSecurityNumber { get; set; }
        
        [Required]
        [Display(Name = "Credit Card Expiration Month")]
        //[StringLength(2)]
        public int CreditCardMonth { get; set; }

        [Required]
        [Display(Name = "Credit Card Expiration Year")]
        //[StringLength(4)]
        public int CreditCardYear { get; set; }
    }
}