using System.ComponentModel.DataAnnotations.Schema;

namespace E_COMMERCEMVC.Models
{
    public class CartItem
    {
        public int Id { set; get; }
        [ForeignKey("Product")]
        public int ProductId { set; get; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
