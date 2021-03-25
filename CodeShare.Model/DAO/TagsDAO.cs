using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeShare.Model.EF;

namespace CodeShare.Model.DAO
{
    public class TagsDAO
    {
        private DataShareCodeEntities db = new DataShareCodeEntities();

        // Hàm thêm
        public bool Create(Tags tags)
        {
            try
            {
                tags.tag_active = false;
                tags.tag_datecreate = DateTime.Now;
                tags.tag_update = DateTime.Now;
                tags.tag_option = true;
                tags.tag_bin = false;
                db.Tags.Add(tags);
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
                Tags tags = db.Tags.Find(id);
                db.Tags.Remove(tags);
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Hàm sửa
        public bool Edit(Tags tags)
        {
            try
            {
                db.Entry(tags).State = EntityState.Modified;
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
