using ModelLayerClassLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayerClassLibrary.Interfaces
{
    public interface IUser
    {
        int UserID { get; set; }
        bool IsIndividual { get; set; }
        string Name { get; set; }
        string IDNumber { get; set; }
        string Email { get; set; }
        PhoneNumber PhoneNumber { get; set; }
        Address Address { get; set; }

        bool IsValid();
    }
}
