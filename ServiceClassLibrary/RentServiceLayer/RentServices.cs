using ModelLayerClassLibrary.Entities;
using ModelLayerClassLibrary.Repositories;
using ServiceClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceClassLibrary.CarServiceLayer;
using ServiceClassLibrary.UserServiceLayer;
using ModelLayerClassLibrary.Abstract;

namespace ServiceClassLibrary.RentServiceLayer
{
    public class RentServices : IServiceRent
    {
        private IRepository<Rent> rentRepo = new RentRepository(new WebAppRentSysDbContext());
        private IService<Car> carServices = new CarServices();
        private IService<User> userServices = new UserServices();

        public List<User> GetAllUsers()
        {
            return userServices.GetAll();
        }

        public List<Client> GetClients(string search)
        {
            if (search != null) { 
                search = search.ToUpper();
                return this.GetAllUsers().OfType<Client>().Where(x => x.Name == search || x.IDNumber == search).OrderBy(x => x.Name).ToList();
            }
            else
            {
                return this.GetAllUsers().OfType<Client>().OrderBy(x => x.Name).ToList();
            }
        }

        public List<Car> GetCars(string search)
        {
            if (search != null)
            {
                search = search.ToUpper();
                return this.GetAllCars().Where(x => x.LicensePlate.ToUpper() == search || x.Model.Name.ToUpper() == search || x.Model.Manufacturer.Name.ToUpper() == search).OrderBy(x => x.Model.Manufacturer.Name).ToList();
            }
            else
            {
                return this.GetAllCars().OrderBy(x => x.Model.Manufacturer.Name).ToList();
            }
        }

        public List<Car> GetAllCars()
        {
            List<Car> cars = carServices.GetAll();
            var rents = this.GetAll().Select(x => x.CarID);

            cars = cars.Where(x => !rents.Contains(x.CarID)).ToList();

            return cars;
        }

        public List<Rent> GetAll()
        {
            return rentRepo.GetAll().Where(x => x.ReturnDate > DateTime.Now).ToList();
        }

        public Rent GetByID(int id)
        {
            return rentRepo.GetByID(id);
        }

        public void Add(Rent item)
        {
            rentRepo.Add(item);
        }

        public void Delete(int id)
        {
            rentRepo.Delete(id);
        }

        public void Update(Rent item)
        {
            rentRepo.Update(item);
        }

        public void Save()
        {
            rentRepo.Save();
        }

        public void Dispose()
        {
            rentRepo.Dispose();
        }
    }
}
