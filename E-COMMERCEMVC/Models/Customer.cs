using System.ComponentModel.DataAnnotations;

namespace E_COMMERCEMVC.Models
{
    
    public class Customer
    {

        public int Id { set; get; }
        [MinLength(3, ErrorMessage = "first name must be more than 2 char")]
        [MaxLength(25, ErrorMessage = "first name must be less than 25 char")]
        public string FirstName { get; set; }
        [MinLength(3, ErrorMessage = " last name must be more than 2 char")]
        [MaxLength(25, ErrorMessage = "last name must be less than 25 char")]
        public string LastName { get; set; }
        [RegularExpression("^[a-zA-Z]+@[a-zA-Z]+\\.(com)$", ErrorMessage = "Email must be contain @ and end with .com ")]
        [UniqueEmail]
        public string Email { get; set; }
        public string Address { get; set; }

        public string PhoneNumber { get; set; }
        public List<Order> Orders { get; set; }
        [MinLength(8, ErrorMessage = " Password must be more than 8 number ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
       

    }
}
