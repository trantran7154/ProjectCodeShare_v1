using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeShare.Frontend.ViewModels
{
    public class ViewComment
    {
        public string user_id { get; set; }
        public string code_id { get; set; }
        public string news_id { get; set; }
        public string comment_content { get; set; }
    }

    public class ViewRep
    {
        public string user_id { get; set; }
        public string comment_id { get; set; }
        public string rep_content { get; set; }
    }
}