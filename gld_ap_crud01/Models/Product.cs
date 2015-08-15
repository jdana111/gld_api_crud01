using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gld_ap_crud01.Models
{
    public class Property
    {
        public int id { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public string street_name { get; set; }
    }
}