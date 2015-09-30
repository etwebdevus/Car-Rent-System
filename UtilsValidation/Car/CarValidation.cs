using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilsValidation.Car
{
    public static class CarValidation
    {
        public static bool ValidateLicensePlate(string plate)
        {
            int cont = 0;
            if (plate.Length == 7 && Utils.OnlyCharAndNumber(plate))
            {
                foreach (char ch in plate)
                {
                    if (cont < 3)
                    {
                        if (!char.IsLetter(ch))
                        {
                            return false;
                        }
                        else
                        {
                            cont++;
                        }
                    }
                    else
                    {
                        if (ch < '0' || ch > '9')
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ValidatePrice(decimal price)
        {
            if (price < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
