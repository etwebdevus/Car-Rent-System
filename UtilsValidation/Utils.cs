using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilsValidation
{
    public static class Utils
    {
        public static bool OnlyNumber(string str)
        {
            foreach (char ch in str)
            {
                if (ch < '0' || ch > '9')
                {
                    return false;
                }
            }

            return true;
        }
    }
}
