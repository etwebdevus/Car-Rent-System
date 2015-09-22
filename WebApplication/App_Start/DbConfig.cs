using ModelLayerClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication.App_Start
{
    public static class DbConfig
    {
        public static void RegisterDb()
        {
            Database.SetInitializer<WebAppRentSysDbContext>(new WebAppDbContextInitializer());
        }
    }
}