using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIDemowithEF1.Entities;

namespace WebAPIDemowithEF1.Contracts
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomers();
        Customer Find(int customerId);
        Customer Add(Customer customer);
    }
}
