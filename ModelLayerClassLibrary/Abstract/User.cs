using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayerClassLibrary.Utils;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using UtilsValidation.UserValidation;

namespace ModelLayerClassLibrary.Abstract
{
    public abstract class User
    {
        public int UserID { get; set; }
        public bool IsIndividual { get; set; }

        private string name;
        public string Name
        {
            get
            {
               return name;
            }
            set
            {
                value = value.ToUpper();
                if (ClientValidation.ValidateName(value))
                {
                    name = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Invalid name value.");
                }

            }
        }

        private string idnumber;
        public string IDNumber
        {
            get
            {
                return idnumber;
            }
            set 
            {
                value = value.Replace(".", "").Replace("-", "");
                if (ClientValidation.ValidateCpf(value) || ClientValidation.ValidateCnpj(value))
                {
                    idnumber = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Invalid ID Number value found.");
                }
            }
        }

        private string email;
        public string Email 
        {
            get
            {
                return email;                
            }
            set 
            {
                if (ClientValidation.ValidateEmail(value))
                {
                    email = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Invalid Email value found.");
                }
            }
        }

        private PhoneNumber phonenumber;
        public PhoneNumber PhoneNumber 
        {
            get
            {
                return phonenumber;
            }
            set
            {
                value.Phone = value.Phone.Replace("-", "").Replace(" ", "");
                value.DDD = value.DDD.Replace("(", "").Replace(")", "");

                if (ClientValidation.ValidatePhoneNumber(value.Phone) && ClientValidation.ValidatePhoneDDD(value.DDD))
                {
                    phonenumber = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Invalid Phone value.");
                }
                
            }
        }

        private Address address;
        public Address Address 
        {
            get
            {
                return address;
            }
            set
            {
                value.City = value.City.ToUpper();
                value.Street = value.Street.ToUpper();
                value.District = value.District.ToUpper();

                if (ClientValidation.ValidateCity(value.City) && ClientValidation.ValidateStreet(value.Street) && ClientValidation.ValidateDistrict(value.District))
                {
                    address = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Invalid Address value.");
                }
            }
        }
    }
}
