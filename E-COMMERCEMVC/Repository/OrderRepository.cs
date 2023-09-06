using E_COMMERCEMVC.Models;

namespace E_COMMERCEMVC.Repository
{
    public class OrderRepository : IOrder
    {
        Context context;
        public OrderRepository()
        {
            context = new Context();
        }
        //public void DeleteById(int OrderNumber)
        //{
        //    Order order=GetById(OrderNumber);
        //    context.Orders.Remove(order);
        //}

        //public List<Order> GetAllByCostomer(int customerid)
        //{
        //    return context.Orders.Where(o => o.CustomerId == customerid).ToList();
        //}
        //public List<Order> GetAllByDate(DateTime OrderDate)
        //{
        //    return context.Orders.Where(o => o.OrderDate == OrderDate).ToList();
        //}
        public Order GetById(int OrderNumber)
        {
            return context.Orders.FirstOrDefault(o => o.OrderNumber == OrderNumber);
        }

        public void Insert(Order item)
        {
            context.Orders.Add(item);
        }

        //public void Update(int OrderNumber, Order order)
        //{
        //    Order orderModel = GetById(OrderNumber);
        //    orderModel.OrderDate = DateTime.Today;
        //}
        
    }
}
