using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeShare.Model.DAO
{
    public class ChatsDao
    {
        public int id { get; set; }
        public Nullable<int> user_id { get; set; }
        public string content { get; set; }
        public Nullable<System.DateTime> datecreate { get; set; }
        public Nullable<int> id_send { get; set; }
        public string key { get; set; }
    }
}
