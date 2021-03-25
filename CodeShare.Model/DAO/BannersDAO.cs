using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeShare.Model.EF;

namespace CodeShare.Model.DAO
{
    public class BannersDAO
    {
        private DataShareCodeEntities db = new DataShareCodeEntities();
        // Hàm thêm
        public bool Create(Banners banners)
        {
            try
            {
                banners.banner_datecreate = DateTime.Now;
                banners.banner_update = DateTime.Now;
                banners.banner_bin = false;

                db.Banners.Add(banners);
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
                Banners banners = db.Banners.Find(id);
                db.Banners.Remove(banners);
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Hàm sửa
        public bool Edit(Banners banners)
        {
            try
            {
                banners.banner_update = DateTime.Now;

                db.Entry(banners).State = EntityState.Modified;
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Hàm Active
        public bool Active(int? id)
        {
            try
            {
                Banners banners = db.Banners.Find(id);
                banners.banner_active = !banners.banner_active;
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        // Hàm Option
        public bool Option(int? id)
        {
            try
            {
                Banners banners = db.Banners.Find(id);
                banners.banner_option = !banners.banner_option;
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Hàm Bin
        public bool Bin(int? id)
        {
            try
            {
                Banners banners = db.Banners.Find(id);
                banners.banner_bin = !banners.banner_bin;
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Hàm Restore
        public bool Restore(int? id)
        {
            try
            {
                Banners banners = db.Banners.Find(id);
                banners.banner_bin = !banners.banner_bin;
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
