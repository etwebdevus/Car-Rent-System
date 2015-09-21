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
    public class ClientController : Controller
    {
        private UserRepository userRepo = new UserRepository(new WebAppRentSysDbContext());

        // GET: /Client/
        public ActionResult Index()
        {
            return View(userRepo.GetAll().OfType<Client>().OrderBy(x => x.Name));
        }

        // GET: /Client/Details/5
        public PartialViewResult Details(int? id)
        {
            if (id == null)
            {
                return PartialView("_ObjectNotFound");
            }
            Client client = (Client) userRepo.GetByID(id.Value);
            if (client == null)
            {
                return PartialView("_ObjectNotFound");
            }
            return PartialView("_ClientDetails", client);
        }

        // GET: /Client/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Client/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,IsIndividual,Name,IDNumber,Email,PhoneNumber,Address,CreditCard")] Client client)
        {
            if (ModelState.IsValid)
            {
                userRepo.Add(client);
                userRepo.Save();
                return RedirectToAction("Index");
            }

            return View(client);
        }

        // GET: /Client/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = (Client) userRepo.GetByID(id.Value);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: /Client/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,IsIndividual,Name,IDNumber,Email,PhoneNumber,Address,CreditCard")] Client client)
        {
            if (ModelState.IsValid)
            {
                userRepo.Update(client);
                userRepo.Save();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: /Client/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = (Client)userRepo.GetByID(id.Value);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: /Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = (Client)userRepo.GetByID(id);
            userRepo.Delete(client.UserID);
            userRepo.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                userRepo.Dispose();
            }
            base.Dispose(disposing);
        }

        public PartialViewResult SortByName()
        {
            return PartialView("_ClientList", userRepo.GetAll().OfType<Client>().OrderBy(x => x.Name));
        }

        public PartialViewResult SortByID()
        {
            return PartialView("_ClientList", userRepo.GetAll().OfType<Client>().OrderBy(x => x.IDNumber));
        }
    }
}
