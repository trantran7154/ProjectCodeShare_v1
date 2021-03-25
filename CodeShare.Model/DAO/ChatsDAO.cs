using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeShare.Model.EF;

namespace CodeShare.Model.DAO
{
    public class ChatsDAO
    {
        private DataShareCodeEntities db = new DataShareCodeEntities();
        // Hàm thêm
        public bool Create(Chats chats)
        {
            try
            {
                db.Chats.Add(chats);
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
                Chats chats = db.Chats.Find(id);
                db.Chats.Remove(chats);
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        // Hàm sửa
        public bool Edit(Chats chats)
        {
            try
            {
                db.Entry(chats).State = EntityState.Modified;
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
                Chats chats = db.Chats.Find(id);
                chats.chat_active = !chats.chat_active;
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Hàm Option
        public bool Option(int? id)
        {
            try
            {
                Chats chats = db.Chats.Find(id);
                chats.chat_option = !chats.chat_option;
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Hàm Bin
        public bool Bin(int? id)
        {
            try
            {
                Chats chats = db.Chats.Find(id);
                chats.chat_bin = !chats.chat_bin;
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Hàm Restore
        public bool Restore(int? id)
        {
            try
            {
                Chats chats = db.Chats.Find(id);
                chats.chat_bin = !chats.chat_bin;
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
