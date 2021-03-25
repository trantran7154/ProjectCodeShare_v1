using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeShareProject.Frontend.Models
{
    public class jNews
    {
        public int id { get; set; }
        public string name { get; set; }
        public Nullable<int> view { get; set; }
        public string content { get; set; }
        public string tag { get; set; }
        public Nullable<int> id_us { get; set; }
        public string datecreate { get; set; }
        public string dateupdate { get; set; }
        public int active { get; set; }
        public Nullable<bool> option { get; set; }
        public Nullable<bool> del { get; set; }
    }
}