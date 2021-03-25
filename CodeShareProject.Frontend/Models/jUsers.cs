using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeShareProject.Frontend.Models
{
    public class jUsers
    {
        public int id { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public Nullable<bool> sex { get; set; }
        public string birth { get; set; }
        public string token { get; set; }
        public int role { get; set; }
        public string name { get; set; }
        public int coin { get; set; }
        public string datecreate { get; set; }
        public string dateupdate { get; set; }
        public string code { get; set; }
        public int active { get; set; }
        public Nullable<bool> option { get; set; }
        public Nullable<bool> del { get; set; }
        public string fa { get; set; }
        public string none { get; set; }
        public int view { get; set; }
        public string facode { get; set; }
    }
}