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
            Mapper.Reset();
            Mapper.CreateMap<ManufacturerRepository, ModelViewModel>().ForMember(dest => dest.Manufacturers, opt => opt.MapFrom(src => new SelectList(src.GetAll(), "ManufacturerID", "Name")))
                                                                      .ForMember(dest => dest.Category, opt => opt.MapFrom(src => 0))
                                                                      .ForMember(dest => dest.Engine, opt => opt.MapFrom(src => 0))
                                                                      .ForMember(dest => dest.ManufacturerID, opt => opt.MapFrom(src => 1))
                                                                      .ForMember(dest => dest.Manufacturer, opt => opt.MapFrom(src => new Manufacturer()))
                                                                      .ForMember(dest => dest.Name, opt => opt.MapFrom(src => ""))
                                                                      .ForMember(dest => dest.ModelID, opt => opt.MapFrom(src => 0));
            
            ModelViewModel mvmCreate = Mapper.Map<ManufacturerRepository, ModelViewModel>(manuRepo);

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
                //Model model = Mapper.Map<ModelViewModel, Model>(mvm);
                Model model = new Model
                {
                    Category = mvmCreate.Category,
                    Engine = mvmCreate.Engine,
                    ManufacturerID = mvmCreate.ManufacturerID,
                    Name = mvmCreate.Name
                };

                modelRepo.Add(model);

                modelRepo.Save();
                return RedirectToAction("Index");
            }

            return View(mvmCreate);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ModelID,Name,Engine,Category,ManufacturerID")] Model model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        modelRepo.Add(model);

        //        modelRepo.Save();
        //        return RedirectToAction("Index");
        //    }

        //    return View(model);
        //}

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

            Mapper.Reset();
            Mapper.CreateMap<ManufacturerRepository, ModelViewModel>().ForMember(dest => dest.Manufacturers, opt => opt.MapFrom(src => new SelectList(src.GetAll(), "ManufacturerID", "Name")))
                                                                      .ForMember(dest => dest.Category, opt => opt.MapFrom(src => model.Category))
                                                                      .ForMember(dest => dest.Engine, opt => opt.MapFrom(src => model.Engine))
                                                                      .ForMember(dest => dest.ManufacturerID, opt => opt.MapFrom(src => model.ManufacturerID))
                                                                      .ForMember(dest => dest.Manufacturer, opt => opt.MapFrom(src => model.Manufacturer))
                                                                      .ForMember(dest => dest.Name, opt => opt.MapFrom(src => model.Name))
                                                                      .ForMember(dest => dest.ModelID, opt => opt.MapFrom(src => model.ModelID));

            ModelViewModel mvmEdit = Mapper.Map<ManufacturerRepository, ModelViewModel>(manuRepo);

            return View(mvmEdit);
        }

        // POST: /Model/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include="ModelID,Name,Engine,Category,ManufacturerID")] Model model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        modelRepo.Update(model);
        //        modelRepo.Save();
        //        return RedirectToAction("Index");
        //    }
        //    //ViewBag.ManufacturerID = new SelectList(manuRepo.GetAll(), "ManufacturerID", "Name", model.ManufacturerID);
        //    return View(model);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ModelViewModel mvmEdit)
        {
            if (ModelState.IsValid)
            {
                Model model = new Model
                {
                    Category = mvmEdit.Category,
                    Engine = mvmEdit.Engine,
                    ManufacturerID = mvmEdit.ManufacturerID,
                    Name = mvmEdit.Name
                };

                modelRepo.Update(model);
                modelRepo.Save();
                return RedirectToAction("Index");
            }
            //ViewBag.ManufacturerID = new SelectList(manuRepo.GetAll(), "ManufacturerID", "Name", model.ManufacturerID);
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
