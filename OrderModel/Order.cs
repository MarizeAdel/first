using CustomerModel;
using ProductModel;

namespace OrderModel
{
    public class Order
    {
        public int Id { get; set; }
        public Customer customer { get; set; }
        public Product[] proudcts { get; set; }

    }
}
