using E_COMMERCEMVC.Models;

namespace E_COMMERCEMVC.Repository
{
    public interface ICartItem
    {
        public List<CartItem> GetAll();
        public CartItem GetById(int id);
        public void Insert(CartItem item);

        public void Update(int id, CartItem cartItem);
        public void DeleteById(int id);
    }
}
