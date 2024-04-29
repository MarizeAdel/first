using CustomerModel;
using ProductModel;
using System.Dynamic;

namespace OrderModel
{
    public class Order
    {
        public int Id { get; set; }
        private Customer customer { get; set; }
        private List<Product> products = new List<Product>();
        public void AddProuduct(Product prouduct)
        {
            products.Add(prouduct);
        }
        public Order(Customer c)
        {
            customer = c;
            
        }
        public List<Product> GetAll()
        {
            return products;
        }
    }
}
