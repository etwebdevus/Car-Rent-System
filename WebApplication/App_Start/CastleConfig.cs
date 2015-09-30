using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.Core;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace WebApplication.App_Start
{
    public static class CastleConfig
    {
        private static IWindsorContainer container =
        new WindsorContainer();
        public static IWindsorContainer Container
        {
            get { return container; }
        }
        public static void Configure()
        {
            container.Install(FromAssembly.This());
        }
        public static void Unload()
        {
            container.Dispose();
        }
    }
}