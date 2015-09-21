using AutoMapper;
using ModelLayerClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApplication.ViewModel;

namespace WebApplication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            Database.SetInitializer<WebAppRentSysDbContext>(new WebAppDbContextInitializer());

            //using (WebAppRentSysDbContext ctx = new WebAppRentSysDbContext()) {
                Mapper.CreateMap<Model, ModelViewModel>().ForMember(dest => dest.Manufacturers, opt => opt.MapFrom(src =>
                    new SelectList((new WebAppRentSysDbContext()).Manufacturers.ToList(), "ManufacturerID", "Name")));
                Mapper.CreateMap<ModelViewModel, Model>();
            //}
        }
    }
}
