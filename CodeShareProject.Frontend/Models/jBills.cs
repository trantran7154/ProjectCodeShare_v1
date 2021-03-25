using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeShareProject.Frontend.Models
{
    public class jBills
    {
        public int id { get; set; }
        public string datecreate { get; set; }
        public int id_pak { get; set; }
        public int id_us { get; set; }
        public Nullable<bool> active { get; set; }
    }
}