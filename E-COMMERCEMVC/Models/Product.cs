using System.ComponentModel.DataAnnotations.Schema;

namespace E_COMMERCEMVC.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }
        [ForeignKey("Category ")]
        public int CategoryId { set; get; }
        public Category Category { get; set; }
    }
}
