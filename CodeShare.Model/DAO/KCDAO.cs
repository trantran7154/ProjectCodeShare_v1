using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeShare.Model.EF;

namespace CodeShare.Model.DAO
{
    public class KCDAO
    {
        private DataShareCodeEntities db = new DataShareCodeEntities();

        // Hàm thêm
        public bool Create(Knowledge_Categorys knowledge_Categorys)
        {
            try
            {
                knowledge_Categorys.kc_datecreate = DateTime.Now;
                knowledge_Categorys.kc_update = DateTime.Now;

                db.Knowledge_Categorys.Add(knowledge_Categorys);
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
                Knowledge_Categorys knowledge_Categorys = db.Knowledge_Categorys.Find(id);
                db.Knowledge_Categorys.Remove(knowledge_Categorys);
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Hàm sửa
        public bool Edit(Knowledge_Categorys knowledge_Categorys)
        {
            try
            {
                knowledge_Categorys.kc_update = DateTime.Now;

                db.Entry(knowledge_Categorys).State = EntityState.Modified;
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
                Knowledge_Categorys kc = db.Knowledge_Categorys.Find(id);
                kc.kc_active = !kc.kc_active;
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
                Knowledge_Categorys kc = db.Knowledge_Categorys.Find(id);
                kc.kc_option = !kc.kc_option;
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
                Knowledge_Categorys kc = db.Knowledge_Categorys.Find(id);
                kc.kc_bin = !kc.kc_bin;
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
                Knowledge_Categorys kc = db.Knowledge_Categorys.Find(id);
                kc.kc_bin = !kc.kc_bin;
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
