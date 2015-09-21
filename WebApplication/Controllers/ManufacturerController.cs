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

namespace WebApplication.Controllers
{
    public class ManufacturerController : Controller
    {
        private ManufacturerRepository manuRepo = new ManufacturerRepository(new WebAppRentSysDbContext());

        // GET: /Manufacturer/
        public ActionResult Index()
        {
            return View(manuRepo.GetAll().OrderBy(x => x.Name));
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
        public ActionResult Create([Bind(Include="ManufacturerID,Name")] Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                manuRepo.Add(manufacturer);
                manuRepo.Save();
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
            Manufacturer manufacturer = manuRepo.GetByID(id.Value);
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
        public ActionResult Edit([Bind(Include="ManufacturerID,Name")] Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                manuRepo.Update(manufacturer);
                manuRepo.Save();
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
            Manufacturer manufacturer = manuRepo.GetByID(id.Value);
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
            Manufacturer manufacturer = manuRepo.GetByID(id);
            manuRepo.Delete(manufacturer.ManufacturerID);
            manuRepo.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                manuRepo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
