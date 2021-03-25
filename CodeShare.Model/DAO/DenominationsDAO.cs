using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeShare.Model.EF;

namespace CodeShare.Model.DAO
{
    public class DenominationsDAO
    {
        private DataShareCodeEntities db = new DataShareCodeEntities();

        // Hàm thêm
        public bool Create(Denominations denominations)
        {
            try
            {
                denominations.denomination_datecreate = DateTime.Now;
                denominations.denomination_update = DateTime.Now;

                db.Denominations.Add(denominations);
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
                Denominations denominations = db.Denominations.Find(id);
                db.Denominations.Remove(denominations);
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Hàm sửa
        public bool Edit(Denominations denominations)
        {
            try
            {
                denominations.denomination_update = DateTime.Now;

                db.Entry(denominations).State = EntityState.Modified;
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Active
        public bool Active(int? id)
        {
            try
            {
                Denominations denominations = db.Denominations.Find(id);
                denominations.denomination_active = !denominations.denomination_active;
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Option
        public bool Option(int? id)
        {
            try
            {
                Denominations denominations = db.Denominations.Find(id);
                denominations.denomination_option = !denominations.denomination_option;
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Bin
        public bool Bin(int? id)
        {
            try
            {
                Denominations denominations = db.Denominations.Find(id);
                denominations.denomination_bin = !denominations.denomination_bin;
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Restore
        public bool Restore(int? id)
        {
            try
            {
                Denominations denominations = db.Denominations.Find(id);
                denominations.denomination_bin = !denominations.denomination_bin;
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
