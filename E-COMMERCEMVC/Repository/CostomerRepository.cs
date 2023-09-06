using E_COMMERCEMVC.Models;
using Microsoft.Identity.Client;

namespace E_COMMERCEMVC.Repository
{
    public class CostomerRepository:ILogin
    {
        Context context;
        public CostomerRepository(Context context)
        {
            this.context = context;
        }
        public void Insert(Customer item)
        {
            context.Customers.Add(item);
            context.SaveChanges();
        }

        public bool Found(string Email, string password)
        {
            var found = context.Customers.FirstOrDefault(a => a.Email == Email && a.Password == password);
            if (found != null)
            {
               
                return true;
            }
            return false;
        }

        public bool Reset(string OldPassword, string Newpassword)
        {
            Customer customer = context.Customers.FirstOrDefault(a => a.Password == OldPassword);
            if (customer != null)
            {
                customer.Password = Newpassword;
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        Customer ILogin.find(string Email, string password)
        {
            Customer acount = context.Customers.FirstOrDefault(a => a.Email == Email && a.Password == password);
            return acount;
        }
    }
}
