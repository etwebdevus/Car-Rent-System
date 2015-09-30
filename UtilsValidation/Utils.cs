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

               // if (char.IsDigit(ch))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool OnlyChar(string str)
        {
            foreach (char ch in str)
            {
                //if ((ch < 'a' || ch > 'z') && (ch < 'A' || ch > 'Z') && ch != ' ')
                if(!char.IsLetter(ch) && ch != ' ')
                {
                    return false;
                }
            }
            return true;
        }

        public static bool OnlyCharAndNumber(string str)
        {
            
            foreach (char ch in str)
            {
                //if (((ch < 'a' || ch > 'z') && (ch < 'A' || ch > 'Z') && (ch < '0' || ch > '9')) && ch != ' ')
                if (!char.IsLetter(ch) && !(ch >= '0' && ch <= '9') && ch != ' ')
                {
                    return false;
                }
            }
            return true;
        }


    }
}
