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
using WebApplication.ViewModel.Client;
using AutoMapper;
using ModelLayerClassLibrary.Abstract;
using ServiceClassLibrary.UserServiceLayer;
using ServiceClassLibrary.Interfaces;

namespace WebApplication.Controllers
{
    public class ClientController : Controller
    {
        //private IRepository<User> userRepo = new UserRepository(new WebAppRentSysDbContext());
        private IService<User> userServices = new UserServices();

        // GET: /Client/
        public ActionResult Index()
        {
            List<Client> clients = userServices.GetAll().OfType<Client>().OrderBy(x => x.Name).ToList();
            List<ClientViewModel> clientsViewModel = new List<ClientViewModel>();

            foreach (Client client in clients)
            {
                clientsViewModel.Add(Mapper.Map<Client, ClientViewModel>(client));
            }

            return View(clientsViewModel);
        }

        // GET: /Client/Details/5
        public PartialViewResult Details(int? id)
        {
            if (id == null)
            {
                return PartialView("_ObjectNotFound");
            }
            Client client = (Client) userServices.GetByID(id.Value);
            if (client == null)
            {
                return PartialView("_ObjectNotFound");
            }
            return PartialView("_ClientDetails", Mapper.Map<Client, ClientViewModel>(client));
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
        public ActionResult Create(ClientViewModel client)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    userServices.Add(Mapper.Map<ClientViewModel, Client>(client));
                    userServices.Save();
                    return RedirectToAction("Index");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    HandleErrorInfo error = new HandleErrorInfo(ex, "CarController", "Create");
                    return View("Error", error);
                }
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
            Client client = (Client) userServices.GetByID(id.Value);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Client, ClientViewModel>(client));
        }

        // POST: /Client/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClientViewModel client)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    userServices.Update((Mapper.Map<ClientViewModel, Client>(client)));
                    userServices.Save();
                    return RedirectToAction("Index");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    HandleErrorInfo error = new HandleErrorInfo(ex, "CarController", "Create");
                    return View("Error", error);
                }
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
            Client client = (Client)userServices.GetByID(id.Value);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Client, ClientViewModel>(client));
        }

        // POST: /Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = (Client)userServices.GetByID(id);
            userServices.Delete(client.UserID);
            userServices.Save();
            return RedirectToAction("Index");
        }

        public PartialViewResult SortByName()
        {
            List<Client> clients = userServices.GetAll().OfType<Client>().OrderBy(x => x.Name).ToList();
            List<ClientViewModel> clientsViewModel = new List<ClientViewModel>();

            foreach (Client client in clients)
            {
                clientsViewModel.Add(Mapper.Map<Client, ClientViewModel>(client));
            }
            return PartialView("_ClientList", clientsViewModel);
        }

        public PartialViewResult SortByID()
        {
            List<Client> clients = userServices.GetAll().OfType<Client>().OrderBy(x => x.IDNumber).ToList();
            List<ClientViewModel> clientsViewModel = new List<ClientViewModel>();

            foreach (Client client in clients)
            {
                clientsViewModel.Add(Mapper.Map<Client, ClientViewModel>(client));
            }
            return PartialView("_ClientList", clientsViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                userServices.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
