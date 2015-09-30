using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModelLayerClassLibrary.Entities;
using ServiceClassLibrary.RentServiceLayer;
using ServiceClassLibrary.CarServiceLayer;
using ServiceClassLibrary.UserServiceLayer;
using WebApplication.ViewModel.Rent;
using AutoMapper;
using WebApplication.ViewModel.Client;
using ModelLayerClassLibrary.Abstract;
using WebApplication.ViewModel.Car;
using ServiceClassLibrary.Interfaces;

namespace WebApplication.Controllers
{
    public class RentController : Controller
    {
        private IServiceRent rentServices = new RentServices();

        public ActionResult Index()
        {
            List<Rent> rentList = rentServices.GetAll();
            List<RentViewModel> rentVMList = new List<RentViewModel>();

            foreach (Rent rent in rentList)
            {
                rentVMList.Add(Mapper.Map<Rent, RentViewModel>(rent));
            }

            return View(rentVMList);
        }


        //--------------SEARCH CLIENT--------------//
        public ActionResult SearchClient()
        {
            return View(Mapper.Map<Rent, RentViewModel>(new Rent()));
        }

        public ActionResult SelectClient(RentViewModel rentVM)
        {
            return RedirectToAction("SearchCar", rentVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearchClient(RentViewModel rentVM)
        {
            List<Client> UserList = rentServices.GetClients(rentVM.searchString);

            rentVM.UserList = new List<ClientViewModel>();

            foreach (Client user in UserList)
            {
                rentVM.UserList.Add(Mapper.Map<Client, ClientViewModel>(user));
            }

            return View(rentVM);
        }

        //--------------SEARCH CAR--------------//
        public ActionResult SearchCar(RentViewModel rentVM)
        {
            return View(Mapper.Map<Rent, RentViewModel>(new Rent()));
        }

        public ActionResult SelectCar(RentViewModel rentVM)
        {
            return RedirectToAction("ReviewRent", rentVM);
        }

        [HttpPost, ActionName("SearchCar")]
        [ValidateAntiForgeryToken]
        public ActionResult SearchCarConfirmed(RentViewModel rentVM)
        {
            List<Car> CarList = rentServices.GetCars(rentVM.searchString);

            rentVM.CarList = new List<ListDetailsDeleteCarViewModel>();

            foreach (Car car in CarList)
            {
                rentVM.CarList.Add(Mapper.Map<Car, ListDetailsDeleteCarViewModel>(car));
            }

            return View(rentVM);
        }

        //--------------REVIEW RENT--------------//
        public ActionResult ReviewRent(RentViewModel rentVM)
        {
            return View(rentVM);
        }

        [HttpPost, ActionName("ReviewRent")]
        [ValidateAntiForgeryToken]
        public ActionResult ReviewRentConfirmed(RentViewModel rentVM)
        {
            rentServices.Add(Mapper.Map<RentViewModel, Rent>(rentVM));
            rentServices.Save();
            return RedirectToAction("Index");
        }

        //--------------RETURN CAR--------------//
        public ActionResult Return(RentViewModel rentVM)
        {
            Rent rent = rentServices.GetByID(rentVM.RentID);
            rentVM = Mapper.Map<Rent, RentViewModel>(rent);

            rentVM.ReturnDate = DateTime.Now.ToString("dd/mm/yyyy");
            if ((DateTime.Now - rent.PickupDate).Days != 0) 
            {
                rentVM.Price = (DateTime.Now - rent.PickupDate).Days * rent.Car.Price;
            }
            else
            {
                rentVM.Price = rent.Car.Price;
            }
            return View(rentVM);
        }

        [HttpPost, ActionName("Return")]
        [ValidateAntiForgeryToken]
        public ActionResult ReturnConfirmed(RentViewModel rentVM)
        {
            Rent rent = rentServices.GetByID(rentVM.RentID);
            rent.ReturnDate = DateTime.Now;
            if ((DateTime.Now - rent.PickupDate).Days != 0)
            {
                rent.Price = (DateTime.Now - rent.PickupDate).Days * rent.Car.Price;
            }
            else
            {
                rent.Price = rent.Car.Price;
            }
            rentServices.Update(rent);
            rentServices.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                rentServices.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
