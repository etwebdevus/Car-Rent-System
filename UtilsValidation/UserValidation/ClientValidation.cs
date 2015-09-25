using ModelLayerClassLibrary.Abstract;
using ModelLayerClassLibrary.Entities;
using ModelLayerClassLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UtilsValidation.UserValidation
{
    public static class ClientValidation
    {
        private static bool IsValid(User user)
        {
            if (user.IsIndividual)
            {
                return (ClientValidation.ValidateName(user.Name) && ClientValidation.ValidateEmail(user.Email) && ClientValidation.ValidateCpf(user.IDNumber) && ClientValidation.ValidatePhoneNumber(user.PhoneNumber.Phone) && ClientValidation.ValidateAddress(user.Address) && ClientValidation.ValidateCreditCard(((Client)user).CreditCard));
            }
            else
            {
                return (ClientValidation.ValidateName(user.Name) && ClientValidation.ValidateEmail(user.Email) && ClientValidation.ValidateCnpj(user.IDNumber) && ClientValidation.ValidatePhoneNumber(user.PhoneNumber.Phone) && ClientValidation.ValidateAddress(user.Address) && ClientValidation.ValidateCreditCard(((Client)user).CreditCard));
            }
        }

        private static bool ValidateName(string name)
        {
            if (name != "" || name != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal static bool ValidateCpf(string cpf)
        {
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

        internal static bool ValidateCnpj(string cnpj)
        {
            return true;
        }

        internal static bool ValidateEmail(string email)
        {
            var regexEmail = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            return regexEmail.IsMatch(email);
        }

        internal static bool ValidatePhoneNumber(string phone)
        {
            if (phone.Length < 8 || phone.Length > 9)
            {
                return false;
            }

            foreach (char ch in phone)
            {
                if (ch < '0' || ch > '9')
                {
                    return false;
                }
            }
            return true;
        }

        internal static bool ValidateAddress(Address address)
        {
            return true;
        }

        internal static bool ValidateCreditCard(CreditCard card)
        {
            return true;
        }
    }
}
