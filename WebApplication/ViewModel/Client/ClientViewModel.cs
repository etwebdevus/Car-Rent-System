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
        [StringLength(20)]
        public string Name { get; set; }
        
        [Required]
        [CPF]
        [Display(Name = "ID Number")]
        public string IDNumber { get; set; }

        [Required]
        //[DataType(DataType.EmailAddress)]
        [Email]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "DDD")]
        public string PhoneNumberDDD { get; set; }
        
        [Required]
        [PhoneNumber]
        //[MinLength(8, ErrorMessage="Phone number should have at least 8 numbers")]
        //[MaxLength(9, ErrorMessage = "Phone number should have a maximum of 9 numbers")]
        [Display(Name = "Phone Number")]
        public string PhoneNumberPhone { get; set; }

        [Required]
        [Display(Name = "State")]
        public EnumState AddressState { get; set; }
        
        [Required]
        [Display(Name = "City")]
        [StringLength(20)]
        public string AddressCity { get; set; }
        
        [Required]
        [Display(Name = "Street")]
        public string AddressStreet { get; set; }
        
        [Required]
        [Display(Name = "District")]
        public string AddressDistrict { get; set; }
        
        [Required]
        [Display(Name = "Address Number")]
        [Range(1,5000)]
        public int AddressNumber { get; set; }

        [Required]
        [Display(Name = "Credit Card's owner name")]
        [StringLength(20)]
        public string CreditCardName { get; set; }

        [Required]
        [Display(Name = "Credit Card Number")]
        public string CreditCardNumber { get; set; }

        [Required]
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