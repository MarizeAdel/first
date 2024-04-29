using CustomerModel;
using OrderModel;

namespace ROrder
{
    public class OrderRepo
    {
        public Order order;

        public OrderRepo(Customer cus)
        {
            order = new Order(cus);
        }



    }
}
