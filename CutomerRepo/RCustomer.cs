
using CustomerModel;
using System.Security.Cryptography.X509Certificates;

namespace CustomerRepo
{
    public class RCustomer
    {
        private List<Customer> _customers=new List<Customer>();
        

       
        public List<Customer> GetAll()
        {
            // Return all customers
            return _customers;
        }

        public void AddCustomer(int id,string name)
        {
            // Add a new customer to the list
            _customers.Add(new Customer(id,name));
        }

    }
}
