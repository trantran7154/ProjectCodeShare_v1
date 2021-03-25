using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeShare.Model.EF;

namespace CodeShare.Model.DAO
{
    public class CoursesDAO
    {
        private DataShareCodeEntities db = new DataShareCodeEntities();

        // Hàm thêm
        public bool Create(Courses courses)
        {
            try
            {
                courses.course_datecreate = DateTime.Now;
                courses.course_update = DateTime.Now;

                db.Courses.Add(courses);
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
                Courses courses = db.Courses.Find(id);
                db.Courses.Remove(courses);
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Hàm sửa
        public bool Edit(Courses courses)
        {
            try
            {
                courses.course_update = DateTime.Now;

                db.Entry(courses).State = EntityState.Modified;
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
                Courses courses = db.Courses.Find(id);
                courses.course_active = !courses.course_active;
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
                Courses courses = db.Courses.Find(id);
                courses.course_option = !courses.course_option;
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
                Courses courses = db.Courses.Find(id);
                courses.course_bin = !courses.course_bin;
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
                Courses courses = db.Courses.Find(id);
                courses.course_bin = !courses.course_bin;
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
