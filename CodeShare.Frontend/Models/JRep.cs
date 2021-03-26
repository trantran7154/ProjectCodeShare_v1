using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeShare.Frontend.Models
{
    public class JRep
    {
        public int rep_id { get; set; }
        public Nullable<int> comment_id { get; set; }
        public Nullable<int> user_id { get; set; }
        public string rep_content { get; set; }
        public Nullable<System.DateTime> rep_datecreate { get; set; }
        public Nullable<System.DateTime> rep_dateupdate { get; set; }
    }
}