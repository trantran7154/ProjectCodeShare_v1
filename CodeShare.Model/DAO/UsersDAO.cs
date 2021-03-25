using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeShare.Model.EF;

namespace CodeShare.Model.DAO
{
    public class UsersDao
    {
        private DataShareCodeEntities db = new DataShareCodeEntities();
        public int Login(string email, string password)
        {
            var login = db.Users.SingleOrDefault(t => t.user_email == email && t.user_pass == password);
            if (login != null)
            {
                if (login.user_active == 1 && login.user_option == true && login.user_del == false)
                {
                    // dang nhap thanh cong
                    return 1;
                }
                else if (login.user_del == true)
                {
                    // tai khoan bi xoa
                    return -2;
                }
                else
                {
                    // tai khoan bi khoa
                    return -3;
                }
            }
            else
            {
                // sai tai khoan hoac mat khau
                return -1;
            }
        }

        //Hàm thêm
        public bool Add(User user)
        {
            try
            {
                //user.user_img = "336a83ff-73bf-451e-9671-3cc9968fc53cerik.jpg";
                user.user_datecreate = DateTime.Now;
                //user.user_datelogin = DateTime.Now;
                user.user_token = Guid.NewGuid().ToString();
                user.user_code = "#Music_Admin";
                user.user_del = false;
                user.user_active = 1;
                user.user_coin = 0;
                user.user_option = true;
                user.user_view = 0;
                user.user_role = 2;

                db.Users.Add(user);
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
        //Hàm sửa
        public bool Edit(User user)
        {
            try
            {
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //Hàm xoá
        public bool Delete(int? id)
        {
            try
            {
                User user = db.Users.Find(id);
                db.Users.Remove(user);

                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Option
        public bool Option(int? id)
        {
            try
            {
                User user = db.Users.Find(id);
                user.user_option = !user.user_option;

                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Thùng rác
        public bool Del(int? id)
        {
            try
            {
                User user = db.Users.Find(id);
                user.user_del = true;

                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Khôi Phục
        public bool Restore(int? id)
        {
            try
            {
                User user = db.Users.Find(id);
                user.user_del = false;

                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Reset password
        public bool ResetPassword(int? id, string password)
        {
            try
            {
                db.Users.Find(id).user_pass = password;
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
