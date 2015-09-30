using ModelLayerClassLibrary.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilsValidation.Car;

namespace ModelLayerClassLibrary.Entities
{
    public class Car
    {
        public int CarID { get; set; }
        
        private string licensePlate;
        public string LicensePlate { 
            get
            {
                return licensePlate;
            }
            set 
            {
                if (CarValidation.ValidateLicensePlate(value))
                {
                    licensePlate = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Invalid License Plate.");
                }
            }
        }
        public EnumColor CarColor { get; set; }

        public int ModelID { get; set; }
        public virtual Model Model { get; set; }

        private decimal price;
        public decimal Price {
            get 
            {
                return price;
            }
            set
            {
                if (CarValidation.ValidatePrice(value))
                {
                    price = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Invalid Price.");
                }
            }
            }

        public Car() { }
    }
}
