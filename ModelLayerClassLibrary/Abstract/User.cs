using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayerClassLibrary.Utils;
using System.Text.RegularExpressions;

namespace ModelLayerClassLibrary.Abstract
{
    public abstract class User
    {
        public int UserID { get; set; }
        public bool IsIndividual { get; set; }
        public string Name { get; set; }
        public string IDNumber { get; set; }
        public string Email { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public Address Address { get; set; }

        public bool IsValid()
        {
            if (this.IsIndividual)
            {
                return (this.ValidateName() && this.ValidateEmail() && this.ValidateCpf() && PhoneNumber.IsValid() && Address.IsValid());
            }
            else
            {
                return (this.ValidateName() && this.ValidateEmail() && this.ValidateCnpj() && PhoneNumber.IsValid() && Address.IsValid());
            }
        }

        private bool ValidateName()
        {
            if (this.Name != "" || this.Name != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateCpf()
        {
            string cpf = this.IDNumber;
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digit;
            int sum;
            int rest;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            foreach (char ch in cpf)
            {
                if (ch < '0' || ch > '9')
                {
                    return false;
                }
            }

            if (cpf.Length != 11)
                return false;

            tempCpf = cpf.Substring(0, 9);
            sum = 0;

            for (int i = 0; i < 9; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            rest = sum % 11;

            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit = rest.ToString();
            tempCpf = tempCpf + digit;
            sum = 0;

            for (int i = 0; i < 10; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            rest = sum % 11;

            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit = digit + rest.ToString();

            return cpf.EndsWith(digit);
        }

        private bool ValidateCnpj()
        {
            string cnpj = this.IDNumber;
            return true;
        }

        private bool ValidateEmail()
        {
            var regexEmail = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            return regexEmail.IsMatch(this.Email);
        }

        
    }
}
