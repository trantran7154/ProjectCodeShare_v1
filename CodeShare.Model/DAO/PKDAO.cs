using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeShare.Model.EF;

namespace CodeShare.Model.DAO
{
    public class PKDAO
    {
        private DataShareCodeEntities db = new DataShareCodeEntities();

        // Hàm thêm
        public bool Create(Programming_Knowledges pk)
        {
            try
            {
                pk.pk_datecreate = DateTime.Now;
                pk.pk_update = DateTime.Now;

                db.Programming_Knowledges.Add(pk);
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
                Programming_Knowledges pk = db.Programming_Knowledges.Find(id);
                db.Programming_Knowledges.Remove(pk);
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Hàm sửa
        public bool Edit(Programming_Knowledges pk)
        {
            try
            {
                pk.pk_update = DateTime.Now;

                db.Entry(pk).State = EntityState.Modified;
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Hàm active
        public bool Active(int? id)
        {
            try
            {
                Programming_Knowledges pk = db.Programming_Knowledges.Find(id);
                pk.pk_active = !pk.pk_active;
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Hàm option
        public bool Option(int? id)
        {
            try
            {
                Programming_Knowledges pk = db.Programming_Knowledges.Find(id);
                pk.pk_option = !pk.pk_option;
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Hàm bin
        public bool Bin(int? id)
        {
            try
            {
                Programming_Knowledges pk = db.Programming_Knowledges.Find(id);
                pk.pk_bin = !pk.pk_bin;
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Hàm restore
        public bool Restore(int? id)
        {
            try
            {
                Programming_Knowledges pk = db.Programming_Knowledges.Find(id);
                pk.pk_bin = !pk.pk_bin;
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
