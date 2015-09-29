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

namespace ServiceClassLibrary.UserServiceLayer
{
    public class UserServices : IService<User>
    {

        private IRepository<User> userRepo = new UserRepository(new WebAppRentSysDbContext());

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
