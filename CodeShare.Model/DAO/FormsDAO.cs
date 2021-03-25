using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeShare.Model.EF;

namespace CodeShare.Model.DAO
{
    public class FormsDAO
    {
        private DataShareCodeEntities db = new DataShareCodeEntities();

        // Hàm thêm
        public bool Create(Forms forms)
        {
            try
            {
                db.Forms.Add(forms);
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Hàm xóa
        public bool Delete(int? id)
        {
            try
            {
                Forms forms = db.Forms.Find(id);
                db.Forms.Remove(forms);
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Hàm sửa
        public bool Edit(Forms forms)
        {
            try
            {
                db.Entry(forms).State = EntityState.Modified;
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
