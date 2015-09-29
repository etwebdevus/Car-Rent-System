using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilsValidation.Manufacturer
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    sealed public class NameAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return ManufacturerValidation.ValidateName(value.ToString());
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture,
              ErrorMessageString, name);
        }
    }
}
