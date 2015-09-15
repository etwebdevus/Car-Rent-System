using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayerClassLibrary.Utils;
using ModelLayerClassLibrary.Enum;

namespace ModelLayerClassLibrary.Entities
{
    public class WebAppDbContextInitializer : DropCreateDatabaseAlways<WebAppRentSysDbContext>
    {
        protected override void Seed(WebAppRentSysDbContext rentSys)
        {
            rentSys.Clients.Add(new Client
            {
                UserID = 1,
                Name = "Hartur",
                Address = new Address { City = "Recife", State = EnumState.PE, Number = 233 },
                Email = "hbb@ecomp.poli.br",
                PhoneNumber = new PhoneNumber { DDD = "81", Phone = "92471119" },
                CreditCard = "45645465"
            });
            base.Seed(rentSys);
        }
    }
}
