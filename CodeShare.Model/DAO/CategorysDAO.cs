using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeShare.Model.EF;


namespace CodeShare.Model.DAO
{
    public class CategorysDAO
    {
        private DataShareCodeEntities db = new DataShareCodeEntities();

        // Hàm thêm
        public bool Create(Categorys categorys)
        {
            try
            {   
                //Mac dinh
                categorys.category_datecreate = DateTime.Now;
                categorys.category_update = DateTime.Now;
                categorys.category_bin = false;
                categorys.category_active = false;

                db.Categorys.Add(categorys);
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
                Categorys categorys = db.Categorys.Find(id);
                db.Categorys.Remove(categorys);
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
                Categorys categorys = db.Categorys.Find(id);
                categorys.category_bin = !categorys.category_bin;
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
                Categorys categorys = db.Categorys.Find(id);
                categorys.category_bin = !categorys.category_bin;
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Hàm sửa
        public bool Edit(Categorys categorys)
        {
            try
            {
                categorys.category_update = DateTime.Now;

                db.Entry(categorys).State = EntityState.Modified;
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Hàm chi tiết
        public bool Details(int? id)
        {
            try
            {
                db.Categorys.Find(id);

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
                Categorys categorys = db.Categorys.Find(id);
                categorys.category_active = !categorys.category_active;
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Hàm Tùy Chọn
        public bool Option(int? id)
        {
            try
            {
                Categorys categorys = db.Categorys.Find(id);
                categorys.category_option = !categorys.category_option;
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
