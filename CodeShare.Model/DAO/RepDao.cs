using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeShare.Model.EF;

namespace CodeShare.Model.DAO
{
    public class RepDao
    {
        DataShareCodeEntities db = new DataShareCodeEntities();
        public bool Create(Rep rep)
        {
            try
            {
                rep.rep_datecreate = DateTime.Now;
                db.Reps.Add(rep);
                db.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }

        public bool Edit(Rep rep)
        {
            try
            {
                rep.rep_dateupdate = DateTime.Now;
                db.Entry(rep).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }

        public bool Delete(int? id)
        {
            try
            {
                var rep = db.Reps.Find(id);
                db.Reps.Remove(rep);
                db.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }
    }
}
