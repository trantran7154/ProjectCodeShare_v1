using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeShare.Model.EF;

namespace CodeShare.Model.DAO
{
    public class UsersDAO
    {
        private DataShareCodeEntities db = new DataShareCodeEntities();

        // Hàm thêm
        public bool Create(Users users)
        {
            try
            {
                users.user_datecreate = DateTime.Now;
                users.user_update = DateTime.Now;

                db.Users.Add(users);
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
                Users users = db.Users.Find(id);
                db.Users.Remove(users);
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Hàm sửa
        public bool Edit(Users users)
        {
            try
            {
                users.user_update = DateTime.Now;

                db.Entry(users).State = EntityState.Modified;
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
                Users users = db.Users.Find(id);
                users.user_active = !users.user_active;
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
                Users users = db.Users.Find(id);
                users.user_option = !users.user_option;
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
                Users users = db.Users.Find(id);
                users.user_bin = !users.user_bin;
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
                Users users = db.Users.Find(id);
                users.user_bin = !users.user_bin;
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
