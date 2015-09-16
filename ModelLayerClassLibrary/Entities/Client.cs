using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayerClassLibrary.Utils;
using System.ComponentModel.DataAnnotations;
using ModelLayerClassLibrary.Abstract;

namespace ModelLayerClassLibrary.Entities
{
    public class Client : User
    {
        //public int UserID { get; set; }
        //public string Name { get; set; }
        //public string IDNumber { get; set; }
        //public string Email { get; set; }
        //public PhoneNumber PhoneNumber { get; set; }
        //public Address Address { get; set; }
        public string CreditCard { get; set; }

        public Client() { }
    }
}
