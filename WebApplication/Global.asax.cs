using AutoMapper;
using ModelLayerClassLibrary.Entities;
using ModelLayerClassLibrary.Repositories;
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
            
            Mapper.CreateMap<Model, ModelViewModel>().ForMember(dest => dest.Manufacturers, opt => opt.MapFrom(src =>
                new SelectList((new ManufacturerRepository(new WebAppRentSysDbContext())).GetAll(), "ManufacturerID", "Name")));
            Mapper.CreateMap<ModelViewModel, Model>();
        }
    }
}