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
using WebApplication.ViewModel.Manufacturer;
using AutoMapper;
using ServiceClassLibrary.Interfaces;
using ServiceClassLibrary.ManufacturerServiceLayer;

namespace WebApplication.Controllers
{
    public class ManufacturerController : Controller
    {
        private IService<Manufacturer> manuServices = new ManufacturerServices();

        // GET: /Manufacturer/
        public ActionResult Index()
        {
            List<Manufacturer> manufacturers = manuServices.GetAll().OrderBy(x => x.Name).ToList();

            List<ManufacturerViewModel> manuViewModel = new List<ManufacturerViewModel>();

            foreach (Manufacturer manu in manufacturers)
            {
                manuViewModel.Add(Mapper.Map<Manufacturer, ManufacturerViewModel>(manu));
            }
            return View(manuViewModel);
        }

        // GET: /Manufacturer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Manufacturer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ManufacturerID,Name")] ManufacturerViewModel manufacturer)
        {
            if (ModelState.IsValid)
            {
                manuServices.Add(Mapper.Map< ManufacturerViewModel, Manufacturer>(manufacturer));
                manuServices.Save();
                return RedirectToAction("Index");
            }

            return View(manufacturer);
        }

        // GET: /Manufacturer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManufacturerViewModel manufacturer = Mapper.Map<Manufacturer, ManufacturerViewModel>(manuServices.GetByID(id.Value));
            if (manufacturer == null)
            {
                return HttpNotFound();
            }
            return View(manufacturer);
        }

        // POST: /Manufacturer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ManufacturerID,Name")] ManufacturerViewModel manufacturer)
        {
            if (ModelState.IsValid)
            {
                manuServices.Update(Mapper.Map < ManufacturerViewModel, Manufacturer>(manufacturer));
                manuServices.Save();
                return RedirectToAction("Index");
            }
            return View(manufacturer);
        }

        // GET: /Manufacturer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManufacturerViewModel manufacturer = Mapper.Map<Manufacturer, ManufacturerViewModel>(manuServices.GetByID(id.Value));
            if (manufacturer == null)
            {
                return HttpNotFound();
            }
            return View(manufacturer);
        }

        // POST: /Manufacturer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Manufacturer manufacturer = manuServices.GetByID(id);
            manuServices.Delete(manufacturer.ManufacturerID);
            manuServices.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                manuServices.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
