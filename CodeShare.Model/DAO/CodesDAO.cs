using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeShare.Model.EF;

namespace CodeShare.Model.DAO
{
    public class CodesDAO
    {
        private DataShareCodeEntities db = new DataShareCodeEntities();
        CategorysDAO categorysDAO = new CategorysDAO();
        CategoryGroupDAO categoryGroupDAO = new CategoryGroupDAO();
        
        // Hàm thêm
        public bool Create(Codes codes, string[] tags)
        {
            try
            {
                // add code
                codes.code_datecreate = DateTime.Now;
                codes.code_update = DateTime.Now;
                codes.code_active = false;
                codes.code_bin = false;
                codes.code_option = true;

                db.Codes.Add(codes);
                db.SaveChanges();

                // get code id
                var codeid = db.Codes.FirstOrDefault(t => t.code_name == codes.code_name && t.user_id == codes.user_id && t.code_active == false).code_id;
                // add tags
                foreach(var item in tags)
                {
                    var categoriesid = item;
                    if (db.Categorys.Where(t => t.category_id.ToString().Contains(item)).Count() == 0)
                    {
                        // add new tags
                        Categorys categorys = new Categorys()
                        {
                            user_id = codes.user_id,
                            category_name = item,
                        };
                        categorysDAO.Create(categorys);
                        categoriesid = db.Categorys.FirstOrDefault(t => t.category_name == item && t.user_id == codes.user_id && t.category_active == false).category_id.ToString();
                    }

                    // add multiple tag for code
                    CategoryGroup tagGroup = new CategoryGroup()
                    {
                        code_id = codeid,
                        category_id = int.Parse(categoriesid),
                    };
                    categoryGroupDAO.Insert(tagGroup);

                }

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
                Codes codes = db.Codes.Find(id);
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
        public bool Edit(Codes codes, string[] tags)
        {
            try
            {
                codes.code_update = DateTime.Now;
                codes.code_active = false;

                db.Entry(codes).State = EntityState.Modified;
                db.SaveChanges();

                // remove old tags
                foreach (var item in codes.CategoryGroup)
                {
                    db.CategoryGroup.Remove(item);
                }
                // add new tags
                foreach (var item in tags)
                {
                    var categoriesid = item;
                    if (db.Categorys.Where(t => t.category_id.ToString().Contains(item)).Count() == 0)
                    {
                        // add new tags
                        Categorys categorys = new Categorys()
                        {
                            user_id = codes.user_id,
                            category_name = item,
                        };
                        categorysDAO.Create(categorys);
                        categoriesid = db.Categorys.FirstOrDefault(t => t.category_name == item && t.user_id == codes.user_id && t.category_active == false).category_id.ToString();
                    }

                    // add multiple tag for code
                    CategoryGroup categoryGroups = new CategoryGroup()
                    {
                        code_id = codes.code_id,
                        category_id = int.Parse(categoriesid),
                    };
                    categoryGroupDAO.Insert(categoryGroups);

                }
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
                Codes codes = db.Codes.Find(id);
                codes.code_active = !codes.code_active;
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
                Codes codes = db.Codes.Find(id);
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
                Codes codes = db.Codes.Find(id);
                codes.code_bin = !codes.code_bin;
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
                Codes codes = db.Codes.Find(id);
                codes.code_bin = !codes.code_bin;
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
