using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModelLayerClassLibrary.Entities;
using ModelLayerClassLibrary.Repositories;
using WebApplication.ViewModel.Car;
using AutoMapper;
using ServiceClassLibrary.Interfaces;
using ServiceClassLibrary.CarServiceLayer;

namespace WebApplication.Controllers
{
    public class CarController : Controller
    {
        private IService<Car> carServices = new CarServices();

        // GET: /Car/
        public ActionResult Index()
        {
            List<Car> cars = carServices.GetAll().OrderBy(x => x.Model.Name).ToList();
            List<ListDetailsDeleteCarViewModel> carsViewModel = new List<ListDetailsDeleteCarViewModel>();

            foreach (Car car in cars)
            {
                carsViewModel.Add(Mapper.Map<Car, ListDetailsDeleteCarViewModel>(car));
            }

            return View(carsViewModel);
        }

        public PartialViewResult SortByName()
        {
            List<Car> cars = carServices.GetAll().OrderBy(x => x.Model.Name).ToList();
            List<ListDetailsDeleteCarViewModel> carsViewModel = new List<ListDetailsDeleteCarViewModel>();

            foreach (Car car in cars)
            {
                carsViewModel.Add(Mapper.Map<Car, ListDetailsDeleteCarViewModel>(car));
            }

            return PartialView("_CarList", carsViewModel);
        }

        public PartialViewResult SortByLicensePlate()
        {
            List<Car> cars = carServices.GetAll().OrderBy(x => x.LicensePlate).ToList();
            List<ListDetailsDeleteCarViewModel> carsViewModel = new List<ListDetailsDeleteCarViewModel>();

            foreach (Car car in cars)
            {
                carsViewModel.Add(Mapper.Map<Car, ListDetailsDeleteCarViewModel>(car));
            }

            return PartialView("_CarList", carsViewModel);
        }

        public PartialViewResult SortByPrice()
        {
            List<Car> cars = carServices.GetAll().OrderBy(x => x.Price).ToList();
            List<ListDetailsDeleteCarViewModel> carsViewModel = new List<ListDetailsDeleteCarViewModel>();

            foreach (Car car in cars)
            {
                carsViewModel.Add(Mapper.Map<Car, ListDetailsDeleteCarViewModel>(car));
            }

            return PartialView("_CarList", carsViewModel);
        }

        public PartialViewResult SortByEngine()
        {
            List<Car> cars = carServices.GetAll().OrderBy(x => x.Model.Engine).ToList();
            List<ListDetailsDeleteCarViewModel> carsViewModel = new List<ListDetailsDeleteCarViewModel>();

            foreach (Car car in cars)
            {
                carsViewModel.Add(Mapper.Map<Car, ListDetailsDeleteCarViewModel>(car));
            }

            return PartialView("_CarList", carsViewModel);
        }

        // GET: /Car/Details/5
        public PartialViewResult Details(int? id)
        {
            if (id == null)
            {
                return PartialView("Error");
            }
            Car car = carServices.GetByID(id.Value);
            if (car == null)
            {
                return PartialView("Error");
            }
            return PartialView("_CarDetails",Mapper.Map<Car, ListDetailsDeleteCarViewModel>(car));
        }

        // GET: /Car/Create
        public ActionResult Create()
        {
            return View(Mapper.Map<Car, CreateEditCarViewModel>(new Car()));
        }

        // POST: /Car/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateEditCarViewModel car)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    carServices.Add(Mapper.Map<CreateEditCarViewModel, Car>(car));
                    carServices.Save();
                    return RedirectToAction("Index");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    HandleErrorInfo error = new HandleErrorInfo(ex, "CarController", "Create");
                    return View("Error", error);
                }
            }

            return View("Index", car);
        }

        // GET: /Car/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = carServices.GetByID(id.Value);
            if (car == null)
            {
                return HttpNotFound();
            }
            var test = Mapper.Map<Car, CreateEditCarViewModel>(car);
            return View(Mapper.Map<Car, CreateEditCarViewModel>(car));
        }

        // POST: /Car/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CreateEditCarViewModel carMvm)
        {
            Car car = Mapper.Map<CreateEditCarViewModel, Car>(carMvm);

            if (ModelState.IsValid)
            {
                try
                {
                    carServices.Update(car);
                    carServices.Save();
                    return RedirectToAction("Index");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    HandleErrorInfo error = new HandleErrorInfo(ex, "CarController", "Create");
                    return View("Error", error);
                }
            }

            return View(carMvm);
        }

        // GET: /Car/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = carServices.GetByID(id.Value);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Car, ListDetailsDeleteCarViewModel>(car));
        }

        // POST: /Car/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car car = carServices.GetByID(id);
            carServices.Delete(car.CarID);
            carServices.Save();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        carServices.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
