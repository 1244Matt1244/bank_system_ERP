public class TransactionRepository : GenericRepository<Transaction>
{
    public TransactionRepository(BankSystemContext context) : base(context)
    {
    }

    // Add any custom transaction-related methods here
}
