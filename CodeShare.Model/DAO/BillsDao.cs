using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeShare.Model.EF;

namespace CodeShare.Model.DAO
{
    public class BillsDao
    {
        private DataShareCodeEntities db = new DataShareCodeEntities();
        // Hàm thêm
        public bool Create(Bill bill)
        {
            try
            {
                //Mac dinh
                bill.bill_datecreate = DateTime.Now;
                bill.bill_active = false;

                db.Bills.Add(bill);
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
                Bill bill = db.Bills.Find(id);
                db.Bills.Remove(bill);
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        // Hàm sửa
        public bool Edit(Bill bill)
        {
            try
            {
                db.Entry(bill).State = EntityState.Modified;
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Hàm chi tiết
        public bool Details(int? id)
        {
            try
            {
                db.Bills.Find(id);

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
                Bill bill = db.Bills.Find(id);
                bill.bill_active = !bill.bill_active;
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
                Bill bill = db.Bills.Find(id);
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
                Bill bill = db.Bills.Find(id);
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Hàm Tùy Chọn
        public bool Option(int? id)
        {
            try
            {
                Bill bill = db.Bills.Find(id);
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
