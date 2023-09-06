using E_COMMERCEMVC.Models;

namespace E_COMMERCEMVC.Repository
{
    public interface IOrder
    {
        //public List<Order> GetAllByCostomer(int customerid);
        //public List<Order> GetAllByDate(DateTime OrderDate);
        public Order GetById(int OrderNumber);
        public void Insert(Order item);

        //public void Update(int OrderNumber, Order order);
        //public void DeleteById(int OrderNumber);
    }
}
