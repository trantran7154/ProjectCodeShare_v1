using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeShare.Frontend.Models
{
    public class jCodes
    {
        public int id { get; set; }
        public string title { get; set; }
        public int coin { get; set; }
        public string code { get; set; }
        public string des { get; set; }
        public string info { get; set; }
        public string setting { get; set; }
        public int view { get; set; }
        public int viewdown { get; set; }
        public string linkdemo { get; set; }
        public string linkdown { get; set; }
        public string datecreate { get; set; }
        public string dateupdate { get; set; }
        public int active { get; set; }
        public Nullable<bool> option { get; set; }
        public Nullable<bool> del { get; set; }
        public string tag { get; set; }
        public int disk { get; set; }
        public string pass { get; set; }
        public int id_cate { get; set; }
        public int id_us { get; set; }
        public string img { get; set; }
    }
}