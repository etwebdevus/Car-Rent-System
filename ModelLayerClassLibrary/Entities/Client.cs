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
        [Display(Name = "Credit Card")]
        public CreditCard CreditCard { get; set; }

        public Client() : base() { }
    }
}
