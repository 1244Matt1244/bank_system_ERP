using System.Collections.Generic;
using System.Linq;

namespace BankIntegration.DataAccessLayer
{
    public class CustomerRepository
    {
        private readonly BankDbContext _context;

        public CustomerRepository(BankDbContext context)
        {
            _context = context;
        }

        public List<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }
    }
}
