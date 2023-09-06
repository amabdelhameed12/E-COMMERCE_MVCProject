using E_COMMERCEMVC.Models;
using Microsoft.Identity.Client;

namespace E_COMMERCEMVC.Repository
{
    public interface ILogin
    {
        public void Insert(Customer item);
        public bool Found (string Email, string password);
        Customer find(string Email, string password);
        public bool Reset(string OldPassword, string Newpassword);
    }
}
