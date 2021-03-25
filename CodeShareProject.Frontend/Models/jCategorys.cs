using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeShareProject.Frontend.Models
{
    public class jCategorys
    {
        public int id { get; set; }
        public string name { get; set; }
        public Nullable<bool> active { get; set; }
        public int item { get; set; }
    }
}