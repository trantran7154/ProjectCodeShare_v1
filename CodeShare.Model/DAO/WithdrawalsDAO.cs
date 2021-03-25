using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeShare.Model.EF;

namespace CodeShare.Model.DAO
{
    public class WithdrawalsDAO
    {
        private DataShareCodeEntities db = new DataShareCodeEntities();

        // Hàm thêm
        public bool Create(Withdrawals withdrawals)
        {
            try
            {
                db.Withdrawals.Add(withdrawals);
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
                Withdrawals withdrawals = db.Withdrawals.Find(id);
                db.Withdrawals.Remove(withdrawals);
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Hàm sửa
        public bool Edit(Withdrawals withdrawals)
        {
            try
            {
                db.Entry(withdrawals).State = EntityState.Modified;
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
                Withdrawals withdrawals = db.Withdrawals.Find(id);
                withdrawals.withdrawal_active = !withdrawals.withdrawal_active;
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
                Withdrawals withdrawals = db.Withdrawals.Find(id);
                withdrawals.withdrawal_option = !withdrawals.withdrawal_option;
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
