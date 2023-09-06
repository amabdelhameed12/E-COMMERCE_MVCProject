using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace E_COMMERCEMVC.Models
{
    public class Order
    {
        [Key]
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public List<Product> Products { get; set; }
        public decimal Total { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { set; get; }
        public Customer Customer { get; set; }

        [ForeignKey("PaymentMethod")]
        public int PaymentMethodId { set; get; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
