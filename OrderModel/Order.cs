using CustomerModel;
using ProductModel;

namespace OrderModel
{
    public class Order
    {
        public int Id { get; set; }
        public Customer customer { get; set; }
        public List<Product> products = new List<Product>();
        public void AddProuduct(Product prouduct)
        {
            products.Add(prouduct);
        }

    }
}
