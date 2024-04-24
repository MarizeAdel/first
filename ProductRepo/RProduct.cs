using ProductModel;

namespace ProductRepo
{
    public class RProduct
    {
        private List<Product> _Prouducts;

        public RProduct()
        {
            // Initialize the Products list
            _Prouducts = new List<Product>();
        }
        public List<Product> GetAll()
        {
            // Return all customers
            return _Prouducts;
        }

        public void AddProduct(Product Product)
        {
            // Add a new customer to the list
            _Prouducts.Add(Product);
        }

    }
}
