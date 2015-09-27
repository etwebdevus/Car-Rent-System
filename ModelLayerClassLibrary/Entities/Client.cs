using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayerClassLibrary.Utils;
using System.ComponentModel.DataAnnotations;
using ModelLayerClassLibrary.Abstract;
using UtilsValidation.UserValidation;

namespace ModelLayerClassLibrary.Entities
{
    public class Client : User
    {

        private CreditCard creditcard;
        public CreditCard CreditCard 
        {
            get
            {
                return creditcard;
            }
            set
            {
                if (ClientValidation.ValidateCreditCardNumber(value.Number) && ClientValidation.ValidateCreditCardSecurityNum(value.SecurityNumber))
                {
                    creditcard = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Invalid Credit Card value found.");
                }
            }
        }

        public Client() : base() { }
    }
}
