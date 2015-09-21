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
using WebApplication.ViewModel;
using AutoMapper;

namespace WebApplication.Controllers
{
    public class ModelController : Controller
    {
        private ModelRepository modelRepo = new ModelRepository(new WebAppRentSysDbContext());
        private ManufacturerRepository manuRepo = new ManufacturerRepository(new WebAppRentSysDbContext());


        // GET: /Model/
        public ActionResult Index()
        {
            return View(modelRepo.GetAll().OrderBy(x => x.Name));
        }

        //// GET: /Model/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Model model = modelRepo.GetByID(id.Value);
        //    if (model == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(model);
        //}

        // GET: /Model/Create
        public ActionResult Create()
        {
            ModelViewModel mvmCreate = Mapper.Map<Model, ModelViewModel>(new Model());

            return View(mvmCreate);
        }

        // POST: /Model/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ModelViewModel mvmCreate)
        {
            if (ModelState.IsValid)
            {
                Model model = Mapper.Map<ModelViewModel, Model>(mvmCreate);

                modelRepo.Add(model);

                modelRepo.Save();
                return RedirectToAction("Index");
            }

            return View(mvmCreate);
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

            ModelViewModel mvmEdit = Mapper.Map<Model, ModelViewModel>(model);

            return View(mvmEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ModelViewModel mvmEdit)
        {
            if (ModelState.IsValid)
            {
                //Mode

                Model model = Mapper.Map<ModelViewModel, Model>(mvmEdit);

                modelRepo.Update(model);
                modelRepo.Save();
                return RedirectToAction("Index");
            }

            return View(mvmEdit);
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
        
        public PartialViewResult ModelDetails(int? id)
        {
            if (id == null)
            {
                return PartialView("_ObjectNotFound");
            }
            Model model = modelRepo.GetByID(id.Value);
            if (model == null)
            {
                return PartialView("_ObjectNotFound");
            }
            return PartialView("_ModelDetails", model);
        }
        [ChildActionOnly]
        public PartialViewResult SortByName()
        {
            return PartialView("_ModelList", this.modelRepo.GetAll().OrderBy(x => x.Name));
        }
        [ChildActionOnly]
        public PartialViewResult SortByManufacturer()
        {
            return PartialView("_ModelList", this.modelRepo.GetAll().OrderBy(x => x.Manufacturer.Name));
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
