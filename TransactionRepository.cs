using System.Collections.Generic;
using System.Linq;

namespace BankIntegration.DataAccessLayer
{
    public class TransactionRepository
    {
        private readonly BankDbContext _context;

        public TransactionRepository(BankDbContext context)
        {
            _context = context;
        }

        public List<Transaction> GetTransactions()
        {
            return _context.Transactions.ToList();
        }
    }
}
