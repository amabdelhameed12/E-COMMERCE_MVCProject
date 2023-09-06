using E_COMMERCEMVC.Models;

namespace E_COMMERCEMVC.Repository
{
    public class CartItemRepository : ICartItem
    {
        Context context;
        public CartItemRepository(Context _context)
        {
            context= _context;
        }
        public void DeleteById(int id)
        {
            CartItem cartItem=GetById(id);
            context.CartItems.Remove(cartItem);
            context.SaveChanges();
        }

        public List<CartItem> GetAll()
        {
            return context.CartItems.ToList();
        }

        public CartItem GetById(int id)
        {
            return context.CartItems.FirstOrDefault(c=>c.Id==id);
        }

        public void Insert(CartItem item)
        {
            context.CartItems.Add(item); 
            context.SaveChanges();
        }

        public void Update(int id, CartItem cartItem)
        {
            CartItem cartItemModel=GetById(id);
            cartItemModel.Quantity = cartItem.Quantity;
            cartItemModel.ProductId= cartItem.ProductId;
            context.SaveChanges();
        }
    }
}
