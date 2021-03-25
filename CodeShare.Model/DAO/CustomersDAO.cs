using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeShare.Model.EF;

namespace CodeShare.Model.DAO
{
    public class CustomersDAO
    {
        private DataShareCodeEntities db = new DataShareCodeEntities();

        // Hàm thêm
        public bool Create(Customers customers)
        {
            try
            {
                customers.customer_datecreate = DateTime.Now;
                customers.customer_update = DateTime.Now;

                db.Customers.Add(customers);
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
                Customers customers = db.Customers.Find(id);
                db.Customers.Remove(customers);
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
                Customers customers = db.Customers.Find(id);
                customers.customer_active = !customers.customer_active;
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
                Customers customers = db.Customers.Find(id);
                customers.customer_option = !customers.customer_option;
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
                Customers customers = db.Customers.Find(id);
                customers.customer_bin = !customers.customer_bin;
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
                Customers customers = db.Customers.Find(id);
                customers.customer_bin = !customers.customer_bin;
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
