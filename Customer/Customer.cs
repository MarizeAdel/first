using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerModel
{

    public class Customer 
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Customer(int id, string name)
        {
            ID = id;
            Name = name;

        }
        override
        public string ToString()
        {
            return $"ID:{ID}Name:{Name}";
        }
    }
}
