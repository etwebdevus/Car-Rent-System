using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilsValidation.Manufacturer
{
    public static class ManufacturerValidation
    {
        public static bool ValidateName(string name)
        {
            if (name.Length > 50)
            {
                return false;
            }

            return Utils.OnlyCharAndNumber(name);
        }
    }
}
