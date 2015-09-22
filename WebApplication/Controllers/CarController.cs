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

namespace WebApplication.Controllers
{
    public class CarController : Controller
    {
        private WebAppRentSysDbContext db = new WebAppRentSysDbContext();
        private CarRepository carRepo = new CarRepository(new WebAppRentSysDbContext());

        // GET: /Car/
        public ActionResult Index()
        {
            List<Car> cars = carRepo.GetAll().OrderBy(x => x.Model.Name).ToList();
            List<ListDetailsDeleteCarViewModel> carsViewModel = new List<ListDetailsDeleteCarViewModel>();

            foreach (Car car in cars)
            {
                carsViewModel.Add(Mapper.Map<Car, ListDetailsDeleteCarViewModel>(car));
            }

            return View(carsViewModel);
        }

        public PartialViewResult SortByName()
        {
            List<Car> cars = carRepo.GetAll().OrderBy(x => x.Model.Name).ToList();
            List<ListDetailsDeleteCarViewModel> carsViewModel = new List<ListDetailsDeleteCarViewModel>();

            foreach (Car car in cars)
            {
                carsViewModel.Add(Mapper.Map<Car, ListDetailsDeleteCarViewModel>(car));
            }

            return PartialView("_CarList", carsViewModel);
        }

        public PartialViewResult SortByLicensePlate()
        {
            List<Car> cars = carRepo.GetAll().OrderBy(x => x.LicensePlate).ToList();
            List<ListDetailsDeleteCarViewModel> carsViewModel = new List<ListDetailsDeleteCarViewModel>();

            foreach (Car car in cars)
            {
                carsViewModel.Add(Mapper.Map<Car, ListDetailsDeleteCarViewModel>(car));
            }

            return PartialView("_CarList", carsViewModel);
        }

        public PartialViewResult SortByEngine()
        {
            List<Car> cars = carRepo.GetAll().OrderBy(x => x.Model.Engine).ToList();
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
            Car car = db.Cars.Find(id);
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateEditCarViewModel car)
        {
            if (ModelState.IsValid)
            {
                db.Cars.Add(Mapper.Map<CreateEditCarViewModel, Car>(car));
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(car);
        }

        // GET: /Car/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
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
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
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
            Car car = db.Cars.Find(id);
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
            Car car = db.Cars.Find(id);
            db.Cars.Remove(car);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
