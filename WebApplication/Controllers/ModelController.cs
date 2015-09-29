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
using WebApplication.ViewModel.Model;
using ServiceClassLibrary.Interfaces;
using ServiceClassLibrary.ManufacturerServiceLayer;
using ServiceClassLibrary.ModelServiceLayer;

namespace WebApplication.Controllers
{
    public class ModelController : Controller
    {
        private IService<Model> modelServices = new ModelServices();
        private IService<Manufacturer> manuServices = new ManufacturerServices();


        // GET: /Model/
        public ActionResult Index()
        {
            List<Model> models = modelServices.GetAll().OrderBy(x => x.Name).ToList();
            List<ListDetailsDeleteModelViewModel> modelsViewModel = new List<ListDetailsDeleteModelViewModel>();
            foreach (Model model in models)
            {
                modelsViewModel.Add(Mapper.Map<Model, ListDetailsDeleteModelViewModel>(model));
            }
            return View(modelsViewModel);
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
            CreateEditModelViewModel mvmCreate = Mapper.Map<Model, CreateEditModelViewModel>(new Model());

            return View(mvmCreate);
        }

        // POST: /Model/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateEditModelViewModel mvmCreate)
        {
            if (ModelState.IsValid)
            {
                Model model = Mapper.Map<CreateEditModelViewModel, Model>(mvmCreate);

                modelServices.Add(model);

                modelServices.Save();
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
            Model model = modelServices.GetByID(id.Value);
            if (model == null)
            {
                return HttpNotFound();
            }

            CreateEditModelViewModel mvmEdit = Mapper.Map<Model, CreateEditModelViewModel>(model);

            return View(mvmEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CreateEditModelViewModel mvmEdit)
        {
            if (ModelState.IsValid)
            {
                //Mode

                Model model = Mapper.Map<CreateEditModelViewModel, Model>(mvmEdit);

                modelServices.Update(model);
                modelServices.Save();
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
            Model model = modelServices.GetByID(id.Value);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Model, ListDetailsDeleteModelViewModel>(model));
        }

        // POST: /Model/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Model model = modelServices.GetByID(id);
            modelServices.Delete(model.ModelID);
            modelServices.Save();
            return RedirectToAction("Index");
        }
        
        public PartialViewResult ModelDetails(int? id)
        {
            if (id == null)
            {
                return PartialView("_ObjectNotFound");
            }
            Model model = modelServices.GetByID(id.Value);
            if (model == null)
            {
                return PartialView("_ObjectNotFound");
            }
            return PartialView("_ModelDetails",Mapper.Map<Model, ListDetailsDeleteModelViewModel>(model));
        }
        
        public PartialViewResult SortByName()
        {
            List<Model> models = modelServices.GetAll().OrderBy(x => x.Name).ToList();
            List<ListDetailsDeleteModelViewModel> modelsViewModel = new List<ListDetailsDeleteModelViewModel>();
            foreach (Model model in models)
            {
                modelsViewModel.Add(Mapper.Map<Model, ListDetailsDeleteModelViewModel>(model));
            }
            return PartialView("_ModelList", modelsViewModel);
        }

        public PartialViewResult SortByManufacturer()
        {
            List<Model> models = modelServices.GetAll().OrderBy(x => x.Manufacturer.Name).ToList();
            List<ListDetailsDeleteModelViewModel> modelsViewModel = new List<ListDetailsDeleteModelViewModel>();
            foreach (Model model in models)
            {
                modelsViewModel.Add(Mapper.Map<Model, ListDetailsDeleteModelViewModel>(model));
            }
            return PartialView("_ModelList", modelsViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                modelServices.Dispose();
                manuServices.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
