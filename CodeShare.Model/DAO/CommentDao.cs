using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeShare.Model.EF;

namespace CodeShare.Model.DAO
{
    public class CommentDao
    {
        DataShareCodeEntities db = new DataShareCodeEntities();
        RepDao repDao = new RepDao();
        public bool Create(Comment comment)
        {
            try
            {
                comment.comment_datecreate = DateTime.Now;
                db.Comments.Add(comment);
                db.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }
        public bool Edit(Comment comment)
        {
            try
            {
                comment.comment_dateupdate = DateTime.Now;
                db.Entry(comment).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }

        public bool Delete(int? id)
        {
            try
            {
                var comment = db.Comments.Find(id);
                foreach(var item in comment.Reps)
                {
                    repDao.Delete(item.rep_id);
                }
                db.Comments.Remove(comment);
                db.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }
    }
}
