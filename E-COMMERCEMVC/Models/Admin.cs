using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace E_COMMERCEMVC.Models
{
    public class Admin
    {
        public int Id { set; get; }
        [DisplayName ( "UserName")]
        public string Name { set; get; }
        public string Password { set; get; }
    }
}
