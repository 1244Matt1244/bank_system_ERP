public class CustomerRepository : GenericRepository<Customer>
{
    public CustomerRepository(BankSystemContext context) : base(context)
    {
    }

    // Add any custom customer-related methods here
}
