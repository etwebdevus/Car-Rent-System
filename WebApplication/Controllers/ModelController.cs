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
    public class ModelController : Controller
    {
        //private WebAppRentSysDbContext db = new WebAppRentSysDbContext();
        private ModelRepository modelRepo = new ModelRepository(new WebAppRentSysDbContext());
        private ManufacturerRepository manuRepo = new ManufacturerRepository(new WebAppRentSysDbContext());

        // GET: /Model/
        public ActionResult Index()
        {
            return View(modelRepo.GetAll().OrderBy(x => x.Name));
        }

        // GET: /Model/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Model model = modelRepo.GetByID(id.Value);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: /Model/Create
        public ActionResult Create()
        {
            ViewBag.ManufacturerID = new SelectList(manuRepo.GetAll(), "ManufacturerID", "Name");
            return View();
        }

        // POST: /Model/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ModelID,Name,Engine,Category,ManufacturerID")] Model model)
        {
            if (ModelState.IsValid)
            {
                modelRepo.Add(model);
                modelRepo.Save();
                return RedirectToAction("Index");
            }

            ViewBag.ManufacturerID = new SelectList(manuRepo.GetAll(), "ManufacturerID", "Name", model.ManufacturerID);
            return View(model);
        }

        // GET: /Model/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Model model = modelRepo.GetByID(id.Value);
            if (model == null)
            {
                return HttpNotFound();
            }
            ViewBag.ManufacturerID = new SelectList(manuRepo.GetAll(), "ManufacturerID", "Name", model.ManufacturerID);
            return View(model);
        }

        // POST: /Model/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ModelID,Name,Engine,Category,ManufacturerID")] Model model)
        {
            if (ModelState.IsValid)
            {
                modelRepo.Update(model);
                modelRepo.Save();
                return RedirectToAction("Index");
            }
            ViewBag.ManufacturerID = new SelectList(manuRepo.GetAll(), "ManufacturerID", "Name", model.ManufacturerID);
            return View(model);
        }

        // GET: /Model/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Model model = modelRepo.GetByID(id.Value);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: /Model/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Model model = modelRepo.GetByID(id);
            modelRepo.Delete(model.ModelID);
            modelRepo.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                modelRepo.Dispose();
                manuRepo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
