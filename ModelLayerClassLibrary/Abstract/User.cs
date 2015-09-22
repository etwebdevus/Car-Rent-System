﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayerClassLibrary.Utils;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace ModelLayerClassLibrary.Abstract
{
    public abstract class User
    {
        public int UserID { get; set; }
        public bool IsIndividual { get; set; }
        public string Name { get; set; }
        public string IDNumber { get; set; }
        public string Email { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public Address Address { get; set; }  
    }
}
