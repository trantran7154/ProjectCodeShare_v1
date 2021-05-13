using CodeShare.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeShare.Common;

namespace CodeShare.Model.DAO
{
    public class CodesDao
    {
        private DataShareCodeEntities db = new DataShareCodeEntities();
        LanguagesDao languagesDao = new LanguagesDao();
        GroupDao groupDao = new GroupDao();

        // Hàm thêm
        public bool Create(Code codes, string[] tags)
        {
            Random r = new Random();
            var key = Guid.NewGuid().ToString();

            try
            {
                // add code
                codes.code_datecreate = DateTime.Now;
                codes.code_dateupdate = DateTime.Now;
                codes.code_active = 2;
                codes.code_del = false;
                codes.code_view = 0;
                codes.code_viewdown = 0;
                codes.code_option = true;
                codes.code_key = key;

                if (codes.code_coin == null)
                {
                    codes.code_coin = 0;
                }
                codes.code_code = "CODE-" + r.Next().ToString();

                db.Codes.Add(codes);
                db.SaveChanges();

                //// get code id
                //Code codeid = db.Codes.SingleOrDefault(n => n.code_key == key);
                //// add tags
                //foreach (var item in tags)
                //{
                //    // add multiple tag for code
                //    Group group = new Group()
                //    {
                //        code_id = codeid.code_id,
                //        language_id = int.Parse(item),
                //        group_item = Common.Common.ITEM_LANGUAGE_CODE
                //    };
                //    groupDao.Create(group);
                //}

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
                Code codes = db.Codes.Find(id);
                db.Codes.Remove(codes);
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        // Hàm sửa
        public bool Edit(Code codes, string[] tags)
        {
            try
            {
                codes.code_dateupdate = DateTime.Now;
                codes.code_active = 2;

                db.Entry(codes).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                // remove old tags
                foreach (var item in codes.Groups)
                {
                    db.Groups.Remove(item);
                }
                //// add new tags
                //foreach (var item in tags)
                //{
                //    // add multiple tag for code
                //    Group group = new Group()
                //    {
                //        code_id = codes.code_id,
                //        language_id = int.Parse(item),
                //        group_item = Common.Common.ITEM_LANGUAGE_CODE
                //    };
                //    groupDao.Create(group);

                //}
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Hàm active
        //public bool Active(int? id)
        //{
        //    try
        //    {
        //        Code codes = db.Codes.Find(id);
        //        codes.code_active = !codes.code_active;
        //        db.SaveChanges();

        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

        // Hàm option
        public bool Option(int? id)
        {
            try
            {
                Code codes = db.Codes.Find(id);
                codes.code_option = !codes.code_option;
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
                Code codes = db.Codes.Find(id);
                codes.code_del = !codes.code_del;
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
                Code codes = db.Codes.Find(id);
                codes.code_del = !codes.code_del;
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
