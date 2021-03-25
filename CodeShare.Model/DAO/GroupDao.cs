using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeShare.Model.EF;

namespace CodeShare.Model.DAO
{
    public class GroupDao
    {
        private DataShareCodeEntities db = new DataShareCodeEntities();
        // Hàm thêm
        public bool Create(Group group)
        {
            try
            {
                db.Groups.Add(group);
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
                Group group = db.Groups.Find(id);
                db.Groups.Remove(group);
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        // Hàm sửa
        public bool Edit(Group group)
        {
            try
            {

                db.Entry(group).State = EntityState.Modified;
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
                db.Groups.Find(id);

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
                Group group = db.Groups.Find(id);
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
                Group group = db.Groups.Find(id);
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
                Group group = db.Groups.Find(id);
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
                Group group = db.Groups.Find(id);
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
