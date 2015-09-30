using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelLayerClassLibrary.Entities;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;

namespace WebApplication.App_Start
{
    public class AppWindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<WebAppDbContextInitializer>().LifestylePerWebRequest());
            container.Register(Classes.FromThisAssembly().BasedOn<Controller>().LifestyleTransient());
        }
    }
}