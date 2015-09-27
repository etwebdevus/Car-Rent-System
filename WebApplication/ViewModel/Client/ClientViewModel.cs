using ModelLayerClassLibrary.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UtilsValidation.UserValidation;

namespace WebApplication.ViewModel.Client
{
    public class ClientViewModel
    {
        public int UserID { get; set; }

        [Required]
        [Display(Name = "Is individual")]
        public bool IsIndividual { get; set; }
        
        [Required]
        [Name]
        public string Name { get; set; }
        
        [Required]
        [IdNumber]
        [Display(Name = "CPF/CNPJ")]
        public string IDNumber { get; set; }

        [Required]
        [Email]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [DDD]
        [Display(Name = "DDD")]
        public string PhoneNumberDDD { get; set; }
        
        [Required]
        [PhoneNumber]
        [Display(Name = "Phone Number")]
        public string PhoneNumberPhone { get; set; }

        [Required]
        [Display(Name = "State")]
        public EnumState AddressState { get; set; }
        
        [Required]
        [City]
        [Display(Name = "City")]
        public string AddressCity { get; set; }
        
        [Required]
        [Street]
        [Display(Name = "Street")]
        public string AddressStreet { get; set; }
        
        [Required]
        [District]
        [Display(Name = "District")]
        public string AddressDistrict { get; set; }
        
        [Required]
        [Display(Name = "Address Number")]
        [Range(1,5000,ErrorMessage="Invalid Address Number")]
        public int AddressNumber { get; set; }

        [Required]
        [CreditCardName]
        [Display(Name = "Credit Card's owner name")]
        public string CreditCardName { get; set; }

        [Required]
        [CreditCardNumber]
        [Display(Name = "Credit Card Number")]
        public string CreditCardNumber { get; set; }

        [Required]
        [CreditCardSecurityNum]
        [Display(Name = "Credit Card Security Number")]
        public string CreditCardSecurityNumber { get; set; }
        
        [Required]
        [Display(Name = "Credit Card Expiration Month")]
        [Range(1,12)]
        public int CreditCardMonth { get; set; }

        [Required]
        [Display(Name = "Credit Card Expiration Year")]
        [Range(2015, 2030)]
        public int CreditCardYear { get; set; }
    }
}