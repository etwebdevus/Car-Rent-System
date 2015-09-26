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
                if (ClientValidation.ValidateOnlyChar(name))
                {
                    return name;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Invalid name value found.");
                }
            }
            set
            {
                if (ClientValidation.ValidateOnlyChar(value))
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
                if (IsIndividual)
                {
                    if (ClientValidation.ValidateCpf(idnumber))
                    {
                        return idnumber;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Invalid CPF value found.");
                    }
                }
                else
                {
                    if (ClientValidation.ValidateCnpj(idnumber))
                    {
                        return idnumber;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Invalid CNPJ value found.");
                    }
                }
                
            }
            set 
            {
                if (IsIndividual)
                {
                    if (ClientValidation.ValidateCpf(value))
                    {
                        idnumber = value;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Invalid CPF value found.");
                    }
                }
                else
                {
                    if (ClientValidation.ValidateCnpj(value))
                    {
                        idnumber = value;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Invalid CNPJ value found.");
                    }
                }
            }
        }

        private string email;
        public string Email 
        { 
            get
            {
                if (ClientValidation.ValidateEmail(email))
                {
                    return email;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Invalid Email value found.");
                }
                
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
                if (ClientValidation.ValidatePhoneNumber(phonenumber.Phone) && ClientValidation.ValidatePhoneDDD(phonenumber.DDD))
                {
                    return phonenumber;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Invalid Phone value found.");
                }
            }
            set
            {
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
                if (ClientValidation.ValidateOnlyChar(address.City) && (address.Street.Length<50) && ClientValidation.ValidateOnlyChar(address.District))
                {
                    return address;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Invalid Address value found.");
                }
            }
            set
            {
                if (ClientValidation.ValidateOnlyChar(value.City) && (value.Street.Length < 50) && ClientValidation.ValidateOnlyChar(value.District))
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
