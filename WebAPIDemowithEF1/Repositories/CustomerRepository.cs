using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIDemowithEF1.Contracts;
using WebAPIDemowithEF1.Entities;

namespace WebAPIDemowithEF1.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        List<Customer> list;
        public CustomerRepository()
        {
            list = new List<Customer>() {
            new Customer(){CustomerID=101, CustomerName="Google"},
            new Customer(){CustomerID=102, CustomerName="Amazon"},
            new Customer(){CustomerID=103, CustomerName="Microsoft"},
            new Customer(){CustomerID=104, CustomerName="Apple"},
            };
        }
        public  Customer Add(Customer customer)
        {
            list.Add(customer);
            return customer;
        }

        public Customer Find(int customerId)
        {
            var result = list.Where (c => c.CustomerID == customerId).FirstOrDefault();
            return result;

        }

        public IEnumerable<Customer> GetCustomers()
        {
            
            return list;
        }
    }
}
