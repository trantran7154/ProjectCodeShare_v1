using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeShare.Frontend.Models
{
    public class JComments
    {
        public int comment_id { get; set; }
        public Nullable<int> user_id { get; set; }
        public Nullable<int> code_id { get; set; }
        public string comment_content { get; set; }
        public Nullable<System.DateTime> comment_datecreate { get; set; }
        public Nullable<int> news_id { get; set; }
        public Nullable<System.DateTime> comment_dateupdate { get; set; }
    }
}