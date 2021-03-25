using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeShare.Model.EF;
using CodeShare.Model.DAO;

namespace CodeShare.Model.DAO
{
    public class CategoryGroupDAO
    {
        DataShareCodeEntities db = new DataShareCodeEntities();
        public bool Insert(CategoryGroup categoryGroups)
        {
            try
            {
                categoryGroups.datecreate = DateTime.Now;
                db.CategoryGroup.Add(categoryGroups);
                db.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }
    }
}
