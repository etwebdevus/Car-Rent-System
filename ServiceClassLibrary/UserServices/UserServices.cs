using ModelLayerClassLibrary.Abstract;
using ModelLayerClassLibrary.Entities;
using ModelLayerClassLibrary.Repositories;
using ModelLayerClassLibrary.Utils;
using ServiceClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ServiceClassLibrary.UserServices
{
    public class UserServices : IService<User>
    {

        private IRepository<User> userRepo = new UserRepository(new WebAppRentSysDbContext());

        public bool IsValid(User user)
        {
            if (user.IsIndividual)
            {
                return (this.ValidateName(user.Name) && this.ValidateEmail(user.Email) && this.ValidateCpf(user.IDNumber) && this.ValidatePhoneNumber(user.PhoneNumber) && this.ValidateAddress(user.Address) && this.ValidateCreditCard(((Client)user).CreditCard));
            }
            else
            {
                return (this.ValidateName(user.Name) && this.ValidateEmail(user.Email) && this.ValidateCnpj(user.IDNumber) && this.ValidatePhoneNumber(user.PhoneNumber) && this.ValidateAddress(user.Address) && this.ValidateCreditCard(((Client)user).CreditCard));
            }
        }

        private bool ValidateName(string name)
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

        private bool ValidateCpf(string cpf)
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

        private bool ValidateCnpj(string cnpj)
        {
            return true;
        }

        private bool ValidateEmail(string email)
        {
            var regexEmail = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            return regexEmail.IsMatch(email);
        }

        private bool ValidatePhoneNumber(PhoneNumber phone)
        {
            return true;
        }

        private bool ValidateAddress(Address address)
        {
            return true;
        }

        private bool ValidateCreditCard(CreditCard card)
        {
            return true;
        }

        public List<User> GetAll()
        {
            return userRepo.GetAll();
        }

        public User GetByID(int id)
        {
            return userRepo.GetByID(id);
        }

        public void Add(User item)
        {
            userRepo.Add(item);
        }

        public void Delete(int id)
        {
            userRepo.Delete(id);
        }

        public void Update(User item)
        {
            userRepo.Update(item);
        }

        public void Save()
        {
            userRepo.Save();
        }

        public void Dispose()
        {
            userRepo.Dispose();
        }
    }
}
